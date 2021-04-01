using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShoot : MonoBehaviour
{
    private BulletPool bulletpool;
    [SerializeField]
    private Transform atkpos;
    private float atkTimer;
    // Start is called before the first frame update
    void Start()
    {
        bulletpool = FindObjectOfType<BulletPool>();
    }

    // Update is called once per frame
    void Update()
    {
        atkTimer -= Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(atkTimer <= 0)
        {
            bulletpool.SpawnBullet(atkpos, 10);
            atkTimer = .5f;
        }
    }
}
