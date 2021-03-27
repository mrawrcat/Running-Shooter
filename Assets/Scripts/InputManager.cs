using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    /*public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouchEvent;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouchEvent;
    */
    #region SwipeEvents
    public delegate void StartTouchPrimaryEvent(Vector2 position, float time);
    public event StartTouchPrimaryEvent OnStartTouchPrimaryEvent;
    public delegate void EndTouchPrimaryEvent(Vector2 position, float time);
    public event EndTouchPrimaryEvent OnEndTouchPrimaryEvent;
    #endregion

    private Camera mainCam;
    private Player playerControls;

    private void Awake()
    {
        playerControls = new Player();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        //playerControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        //playerControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        playerControls.Touch.PrimaryContact.started += ctx => StartTouchPrimary(ctx);
        playerControls.Touch.PrimaryContact.canceled += ctx => EndTouchPrimary(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    private void StartTouch(InputAction.CallbackContext context)
    {
        if(OnStartTouchEvent != null)
        {
            OnStartTouchEvent(playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
        //Debug.Log("Touch Started: " + playerControls.Touch.TouchPosition.ReadValue<Vector2>());
        //Debug.Log(playerControls.Touch.TouchInput.phase);
        
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouchEvent != null)
        {
            OnEndTouchEvent(playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
        //Debug.Log("Touch Ended: " + playerControls.Touch.TouchPosition.ReadValue<Vector2>());
        
    }
    */
    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if(OnStartTouchPrimaryEvent != null)
        {
            OnStartTouchPrimaryEvent(Utils.ScreenToWorld(mainCam, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()) , (float)context.startTime);
        }
        
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouchPrimaryEvent != null)
        {
            OnEndTouchPrimaryEvent(Utils.ScreenToWorld(mainCam, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>()), (float)context.time);
        }
        
    }

    public Vector2 PrimaryPosition()
    {
        return Utils.ScreenToWorld(mainCam, playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }
}
