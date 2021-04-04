using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInput : MonoBehaviour
{
    private PlayerInput playerInput;
    private void Awake()
    {
        playerInput = new PlayerInput();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        
    }
    private void OnDisable()
    {
        playerInput.Disable();
        
    }

    [SerializeField]
    private float upForce;
    private bool goup;
    [SerializeField]
    private float atkRate;
    private float atkTimer;
    private Transform atkPos;
    [SerializeField]
    private float shootSpeed;
    [SerializeField]
    private float forwardSpeed;
    private BulletPool bulletPool;
    private Rigidbody2D rb2d;
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bulletPool = FindObjectOfType<BulletPool>();
        atkPos = transform.GetChild(0).transform;
        
    }

    private void Update()
    {
        if(transform.position.x < -6)
        {
            rb2d.velocity = new Vector2(forwardSpeed, rb2d.velocity.y);
        }
        else if(transform.position.x > -5.5)
        {
            rb2d.velocity = new Vector2(-forwardSpeed, rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }


        atkTimer -= Time.deltaTime;
        if (goup)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, upForce);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            goup = true;
        }
        else if (context.canceled)
        {
            goup = false;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if(atkTimer <= 0)
        {
            atkTimer = atkRate;
            bulletPool.SpawnBullet(atkPos, shootSpeed);
        }
    }
   
}
