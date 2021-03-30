using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAddComponent : MonoBehaviour
{
    private Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        CircleCollider2D sc = gameObject.AddComponent(typeof(CircleCollider2D)) as CircleCollider2D;
        bullet = gameObject.AddComponent(typeof(Bullet)) as Bullet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
