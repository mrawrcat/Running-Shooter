using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent OnStartTouchEvent;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent OnEndTouchEvent;

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
        playerControls.Touch.TouchPress.started += ctx => StartTouch(ctx);
        playerControls.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        if(OnStartTouchEvent != null)
        {
            OnStartTouchEvent(playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
        Debug.Log("Touch Started: " + playerControls.Touch.TouchPosition.ReadValue<Vector2>());
        Debug.Log(playerControls.Touch.TouchInput.phase);
        
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        if (OnEndTouchEvent != null)
        {
            OnEndTouchEvent(playerControls.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
        Debug.Log("Touch Ended: " + playerControls.Touch.TouchPosition.ReadValue<Vector2>());
        
    }

   
}
