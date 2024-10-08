using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;

    [Header("Input Actions")]
    [SerializeField] InputActionReference moveY;
    [SerializeField] InputActionReference scaleY;
    [SerializeField] InputActionReference jump;

    [Header("Parametros")]
    public float jumpForce;
    public float speed;

    private bool isSpecialZone;
    private bool isOnGround;

    private void OnEnable()
    {
        moveY.action.Enable();
        scaleY.action.Enable();
        jump.action.Enable();
    }

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    void OnDestroy()
    {

    }
}
