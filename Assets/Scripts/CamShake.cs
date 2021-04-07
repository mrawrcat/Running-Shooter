using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamShake : MonoBehaviour
{
    public static CamShake camInstance { get; private set; }

    
    private CinemachineVirtualCamera cineCam;
    private float shakeTimer;
    private float startingIntensity;
    private float shakeTimerTotal;
    private void Awake()
    {
        camInstance = this;
        cineCam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        shakeTimer -= Time.deltaTime;
        if(shakeTimer <= 0)
        {
            CinemachineBasicMultiChannelPerlin cineBMCP = cineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            //cineBMCP.m_AmplitudeGain = 0;
            cineBMCP.m_AmplitudeGain = Mathf.Lerp(startingIntensity, 0, (1-( shakeTimer / shakeTimerTotal)));
            
        }
    }

    public void Shake(float intensity, float timer)
    {
        CinemachineBasicMultiChannelPerlin cineBMCP = cineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cineBMCP.m_AmplitudeGain = intensity;
        startingIntensity = intensity;
        shakeTimerTotal = timer;
        if(shakeTimer <= 0)
        {
            shakeTimer = timer;
        }
    }
}
