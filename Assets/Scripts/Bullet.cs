using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float countToDestroy;
    private float countdown;
    private void OnEnable()
    {
        //Debug.Log("bullet script enabled");
        countdown = countToDestroy;
    }
    private void OnDisable()
    {
        //Debug.Log("bullet script disabled");
    }

    private void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            BulletActions.OnBulletHit(this);
            gameObject.SetActive(false);
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Tilemap")
        {
            //BulletActions.OnBulletHit(this);
            gameObject.SetActive(false);
        }
    }
}
