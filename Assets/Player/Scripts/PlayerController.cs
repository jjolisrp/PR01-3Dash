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
    private bool isOnGround;

    Vector3 moveDirection;

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
    }

    void FixedUpdate()
    {
        playerRb.MovePosition(transform.position + moveDirection * Time.deltaTime * gameManager.playerSpeed);
    }

    public void KillPlayer()
    {

    }

    void BannerPortalTransform()
    {

    }

    private void OnDisable()
    {
        moveY.action.Disable();
        scaleY.action.Disable();
        jump.action.Disable();
    }

    void OnJump(InputAction.CallbackContext ctx)
    {
        moveDirection = new Vector3(1, 1, 0);
    }

    void OnDestroy()
    {

    }
}
