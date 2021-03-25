using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class NewInput : MonoBehaviour
{
    private Player playerControls;
    private void Awake()
    {
        playerControls = new Player();
    }
    private void OnEnable()
    {
        playerControls.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;
    }
    private void OnDisable()
    {
        playerControls.Disable();
        TouchSimulation.Disable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    private void Start()
    {
    }

    private void FingerDown(Finger finger)
    {
        
    }
}
