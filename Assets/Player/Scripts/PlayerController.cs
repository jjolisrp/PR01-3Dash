using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core.Easing;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public GameManager gameManager;
    [SerializeField] GameObject playerVisuals;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveY;
    [SerializeField] InputActionReference scaleY;
    [SerializeField] InputActionReference jump;

    private Rigidbody playerRb;
    private BoxCollider[] playerColliders;

    public delegate void OnPlayerKilled();
    public static event OnPlayerKilled PlayerKilled;

    private bool isSpecialZone;
    private bool isGrounded;

    Vector3 moveDirection;
    Vector3 jumpDirection;
    Vector3 startPosition;
    Vector3 startScale;

    Vector2 moveYValue;
    Vector2 scaleYValue;

    [Header("Variables")]
    public float speed;
    public float speedSpecialZone;
    public float jumpSpeed;
    public float ownGravity;

    [Header("Only Read")]
    public int deathCount;

    private void OnEnable()
    {
        moveY.action.Enable();
        scaleY.action.Enable();
        jump.action.Enable();

        jump.action.performed += OnJump;
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerColliders = GetComponents<BoxCollider>();


        moveDirection = new Vector3(1, 0, 0);
        jumpDirection = new Vector3(0, 1, 0);

        startPosition = transform.position;
        startScale = playerVisuals.transform.localScale;

        deathCount = 1;
    }

    void Update()
    {
        if(isSpecialZone)
        {
            //Debug.Log("Leyendo teclas de la zona especial");

            moveYValue = moveY.action.ReadValue<Vector2>();

            scaleYValue = scaleY.action.ReadValue<Vector2>();

            if (playerVisuals.transform.localScale.z > 1f)
            {
                playerVisuals.transform.localScale = new Vector3(playerVisuals.transform.localScale.x, playerVisuals.transform.localScale.y, 1.0f);
            }
            else if (playerVisuals.transform.localScale.z < 0.2f)
            {
                playerVisuals.transform.localScale = new Vector3(playerVisuals.transform.localScale.x, playerVisuals.transform.localScale.y, 0.2f);
            }
        }
    }

    void FixedUpdate()
    {
        if(!isSpecialZone)
        {
            playerRb.velocity = new Vector3(moveDirection.x * speed, playerRb.velocity.y, 0f);

            playerRb.AddForce(Vector3.down * ownGravity);
        }
        else
        {
            playerRb.velocity = new Vector3(moveDirection.x * speed, moveYValue.y * speedSpecialZone, 0f);

            if(playerVisuals.transform.localScale.z < 1.1f && playerVisuals.transform.localScale.z > 0.1f)
            {
                playerVisuals.transform.localScale += new Vector3(0, 0, scaleYValue.y / 20.0f);
            }
        }
        
    }

    public void KillPlayer()
    {
        //FUTURO: Sacar particulas y animacion de muerte
        gameManager.RetryLevel();

        transform.position = startPosition;
        playerVisuals.transform.localScale = startScale;

        deathCount += 1;

        isSpecialZone = false;

        //Reiniciar las variables que se deban cambiar al morir el player usando delegados y eventos
        if(PlayerKilled != null)
        {
            PlayerKilled.Invoke(); //Llama a todas las funciones que esten suscritas al evento
        }
    }

    //POSIBLE PLAYER DESTRANSFORM PARA FUTUROS PORTALES
    //void PlayerDestransform()
    //{
    //    isSpecialZone = false;
    //}

    public void BannerPortalTransform()
    {
        Debug.Log("Tranformando al player");

        isSpecialZone = true;
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        if(isGrounded)
        {
            Vector3 newVelocity = playerRb.velocity;
            newVelocity.y = jumpSpeed;
            playerRb.velocity = newVelocity;

            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)
        {
            isGrounded = true;

            //Debug.Log("Toca el suelo");
        }
        else
        {
            isGrounded = false;
        }

        if(other.gameObject.layer == 11)
        {
            KillPlayer();
        }
    }

    void OnDestroy()
    {

    }

    private void OnDisable()
    {
        moveY.action.Disable();
        scaleY.action.Disable();
        jump.action.Disable();
        
        jump.action.performed -= OnJump;
    }

}
