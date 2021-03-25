using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{

    [SerializeField]
    private InputManager inputManager;
    private Camera main;
    private Rigidbody2D rb2d;
    public float jumpForce;
    [SerializeField]
    private bool goingUp;

    private void OnEnable()
    {
        inputManager.OnStartTouchEvent += Jump;
        inputManager.OnEndTouchEvent += FinishTouch;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouchEvent -= Jump;
        inputManager.OnEndTouchEvent -= FinishTouch;
    }
    private void Awake()
    {
        //inputManager = GetComponent<InputManager>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        main = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (goingUp)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        }
        
    }

    public void pressUp()
    {
        //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        goingUp = true;
    }
    public void releaseUp()
    {
        //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        goingUp = false;
    }

    public void Jump(Vector2 screenPos, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPos.x, screenPos.y, main.nearClipPlane);
        Vector3 worldCoordinates = main.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        if(screenPos.x <= Screen.width / 2)
        {
            Debug.Log("Touch on Left: " + screenPos.x);
            goingUp = true;
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        else if(screenPos.x > Screen.width / 2)
        {

            Debug.Log("Touch on Right: " + screenPos.x);
        }
        
    }

    public void FinishTouch(Vector2 screenPos, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPos.x, screenPos.y, main.nearClipPlane);
        Vector3 worldCoordinates = main.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
        if (screenPos.x <= Screen.width / 2)
        {
            Debug.Log("Finish Touch on Left: " + screenPos.x);
            goingUp = false;
            //rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
        }
        else if (screenPos.x > Screen.width / 2)
        {

            Debug.Log("Touch on Right: " + screenPos.x);
        }
    }
    
}
