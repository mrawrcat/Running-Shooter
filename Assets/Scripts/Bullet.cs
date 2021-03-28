using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("bullet script enabled");
    }
    private void OnDisable()
    {
        Debug.Log("bullet script disabled");
        BulletActions.OnBulletHit(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "wall")
        {
            BulletActions.OnBulletHit(this);
            gameObject.SetActive(false);
        }
    }
}
