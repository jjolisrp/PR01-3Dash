using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public GameManager gameManager;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveY;
    [SerializeField] InputActionReference scaleY;
    [SerializeField] InputActionReference jump;

    private bool isSpecialZone;
    private bool isGrounded;

    Vector3 moveDirection;
    Vector3 jumpDirection;
    Vector3 startPosition;

    public float speed;
    public float jumpSpeed;
    public float ownGravity;

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
        moveDirection = new Vector3(1, 0, 0);
        jumpDirection = new Vector3(0, 1, 0);
        startPosition = transform.position;
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        playerRb.velocity = new Vector3(moveDirection.x * speed, playerRb.velocity.y, 0f);

        playerRb.AddForce(Vector3.down * ownGravity);
    }

    public void KillPlayer()
    {
        //Sacar particulas y animacion de muerte

        transform.position = startPosition;
    }

    public void BannerPortalTransform()
    {

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

    void OnMoveY()
    {
        
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
