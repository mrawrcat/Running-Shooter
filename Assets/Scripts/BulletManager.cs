using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private int bulletCount;

    [SerializeField]
    private Text bulletTxt;
    private float countdown;
    private void OnEnable()
    {
        BulletActions.OnBulletHit += BulletHit;
        BulletActions.BulletTimer += BulletCountdown;
    }

    private void OnDisable()
    {
        BulletActions.OnBulletHit -= BulletHit;
        BulletActions.BulletTimer -= BulletCountdown;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletTxt.text = bulletCount.ToString();


    }

    public void BulletHit(Bullet bullet)
    {
        bulletCount++;
        CamShake.camInstance.Shake(3, .1f);
    }

    public void BulletCountdown(Bullet bullet)
    {

    }
}
