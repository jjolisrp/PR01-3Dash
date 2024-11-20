using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public GameManager gameManager;
    [SerializeField] GameObject playerVisuals;
    [SerializeField] GameObject playerWings;
    [SerializeField] ParticlesManager particlesManager;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveY;
    [SerializeField] InputActionReference scaleY;
    [SerializeField] InputActionReference jump;

    private Rigidbody playerRb;
    private BoxCollider[] playerColliders;

    public delegate void OnPlayerRestarted();
    public static event OnPlayerRestarted PlayerRestarted;

    public delegate void OnPlayerDead();
    public static event OnPlayerDead PlayerDied;

    private bool isGrounded;
    private bool isDead;
    private bool isRestarting;

    int layerMask = 1 << 8;

    Vector3 moveDirection;
    Vector3 startPosition;
    Vector3 startRbPosition;
    Vector3 startScale;
    Vector3 frontRaycastPosition;
    Vector3 backRaycastPosition;

    Vector2 moveYValue;
    Vector2 scaleYValue;

    [Header("Variables")]
    public float speed;
    public float speedSpecialZone;
    public float jumpSpeed;
    public float ownGravity;

    [Header("Only Read")]
    public int deathCount;
    public bool isSpecialZone;

    private void OnEnable()
    {
        moveY.action.Enable();
        scaleY.action.Enable();
        jump.action.Enable();

        jump.action.performed += OnJump;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerColliders = GetComponents<BoxCollider>();


        moveDirection = new Vector3(1, 0, 0);

        startPosition = transform.position;
        startRbPosition = playerRb.position;
        startScale = transform.localScale;

        frontRaycastPosition = new Vector3(0.8f, 0, 0);
        backRaycastPosition = new Vector3(-0.8f, 0, 0);

        deathCount = 1;
        isSpecialZone = false;
    }

    void Update()
    {
        if (isSpecialZone)
        {
            //Leer el valor de los ejes de escalado y movimiento
            moveYValue = moveY.action.ReadValue<Vector2>();

            scaleYValue = scaleY.action.ReadValue<Vector2>();

            //Comprobar que el player no se pase de su escala en el tramo especial
            if (transform.localScale.y > 1.7f)
            {
                transform.localScale = new Vector3(transform.localScale.x, 1.7f, transform.localScale.z);
            }
            else if (transform.localScale.y < 0.2f)
            {
                transform.localScale = new Vector3(transform.localScale.x, 0.2f, transform.localScale.z);
            }
        }
        else
        {
            if (jump.action.phase == InputActionPhase.Performed && isGrounded)
            {
                Vector3 newVelocity = playerRb.velocity;
                newVelocity.y = jumpSpeed;
                playerRb.velocity = newVelocity;

                isGrounded = false;
            }
        }
    }

    void FixedUpdate()
    {
        if(!isSpecialZone && !isDead)
        {
            //Movimiento del tramo normal
            playerRb.velocity = new Vector3(moveDirection.x * speed, playerRb.velocity.y, 0f);

            playerRb.AddForce(Vector3.down * ownGravity);

            if (Physics.Raycast(transform.position + frontRaycastPosition, Vector3.down, 0.4f, layerMask)/* || Physics.Raycast(transform.position + backRaycastPosition, Vector3.down, 0.4f, layerMask)*/)
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else if(isSpecialZone && !isDead)
        {
            //Movimiento del tramo especial
            playerRb.velocity = new Vector3(moveDirection.x * speed, moveYValue.y * speedSpecialZone, 0f);

            //Comprobar si el player está dentro de los parametros de escala y escalarlo si es así
            if(transform.localScale.y < 1.8f && transform.localScale.y > 0.1f)
            {
                transform.localScale += new Vector3(0, scaleYValue.y / 30.0f, 0);
            }
        }
        
    }

    public void KillPlayer()
    {
        if (isRestarting) return; //No permite que se haga más de 1 llamada a la funcion kill player mientras isrestarting este activo

        jump.action.Disable(); //Mirar si hay otra manera de hacerlo

        isDead = true;
        isRestarting = true;

        if(PlayerDied != null)
        {
            PlayerDied.Invoke();
        }

        Invoke("RestartPlayer", 3.0f);

        playerVisuals.SetActive(false);

        particlesManager.EmitParticles(1, transform, ParticlesManager.Particle.PlayerExplosion);

        playerRb.velocity = new Vector3(0, 0, 0);

        isSpecialZone = false;
    }

    public void RestartPlayer()
    {
        gameManager.RetryLevel();

        isDead = false;

        isRestarting = false;

        isSpecialZone = false;

        deathCount += 1;

        playerVisuals.SetActive(true);

        playerWings.SetActive(false);

        //Reiniciar las variables que se deban cambiar al reiniciar el player usando delegados y eventos
        if (PlayerRestarted != null)
        {
            PlayerRestarted.Invoke(); //Llama a todas las funciones que esten suscritas al evento
        }

        transform.position = startPosition;
        playerRb.position = startRbPosition;
        transform.localScale = startScale;

        jump.action.Enable(); //Mirar si hay otra manera de hacerlo
    }

    public void PlayerDestransform()
    {
        isSpecialZone = false;
        transform.localScale = startScale;
        particlesManager.EmitParticles(50, transform, ParticlesManager.Particle.Evaporation);
        playerWings.SetActive(false);
    }

    public void BannerPortalTransform()
    {
        isSpecialZone = true;
        particlesManager.EmitParticles(50, transform, ParticlesManager.Particle.Evaporation);
        playerWings.SetActive(true);
    }

    public void StopPlayer()
    {
        moveDirection = Vector3.zero;

        jump.action.Disable();
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        //if (isGrounded)
        //{
        //    Vector3 newVelocity = playerRb.velocity;
        //    newVelocity.y = jumpSpeed;
        //    playerRb.velocity = newVelocity;

        //    isGrounded = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 11)
        {
            KillPlayer();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        for(int i = 0; i < collision.contacts.Length; i++)
        {
            ContactPoint contact = collision.contacts[i];

            if (contact.thisCollider.name == "whell" && !isDead && contact.otherCollider.gameObject.layer == 11)
            {

                if (contact.normal.y <= 0.8f)
                {
                    KillPlayer();
                }
            }
            
            if(contact.thisCollider.name == "whell.001" && !isDead && contact.otherCollider.gameObject.layer == 11)
            {

                if (contact.normal.y <= 0.8f)
                {
                    KillPlayer();
                }
            }
        }
    }

    private void OnDisable()
    {
        moveY.action.Disable();
        scaleY.action.Disable();
        jump.action.Disable();
        
        jump.action.performed -= OnJump;
    }

}
