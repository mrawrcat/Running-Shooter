using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwipeInput : MonoBehaviour
{
    private InputManager inputManager;
    private Vector2 startPos;
    private float startTime;
    private Vector2 endPos;
    private float endTime;

    private Rigidbody2D rb2d;
    private bool touching;
    private bool goup;

    [SerializeField]
    private float jumpforce;

    private void Awake()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
    private void OnEnable()
    {
        inputManager.OnStartTouchPrimaryEvent += SwipeStart;
        inputManager.OnEndTouchPrimaryEvent += SwipeEnd;
        
    }

    private void OnDisable()
    {
        inputManager.OnStartTouchPrimaryEvent -= SwipeStart;
        inputManager.OnEndTouchPrimaryEvent -= SwipeEnd;
    }
    private void Start()
    {
        touching = false;
        goup = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetPrimaryPos();

        if (goup)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpforce);
        }
        else
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, rb2d.velocity.y);
        }
    }

    private void SwipeStart(Vector2 position, float time)
    {
        touching = true;
        startPos = position;
        startTime = time;

        
        //Debug.Log("touch started at position: " + position);
    }

    private void SwipeEnd(Vector2 position, float time)
    {
        touching = false;
        endPos = position;
        endTime = time;
        //Debug.Log("touch ended at position: " + position);
    }

    private void GetPrimaryPos()
    {
        Vector2 currentPos = inputManager.PrimaryPosition();
        if(touching && currentPos.x <= 0)
        {
            goup = true;
        }
        else
        {
            goup = false;
        }
    }
}
