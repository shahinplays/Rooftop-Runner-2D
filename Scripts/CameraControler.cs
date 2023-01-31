using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float shakeDistance = 0.1f;
    public float shakeSpeed = 1f;

    Vector3 initialPosition;
    Vector3 shakeOffset;

    bool isShaking = true;


    void Start()
    {
        initialPosition = transform.position;

        
    }


    void Update()
    {
        CameraShake();

    }



    private void CameraShake()
    {
        if (isShaking)
        {
            Vector3 pos = transform.position;
            Vector3 offsetPos = pos + shakeOffset;
            float currentDisttance = shakeOffset.y - initialPosition.y;
            if (shakeSpeed >= 0)
            {
                if (currentDisttance > shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }
            else
            {
                if (currentDisttance < -shakeDistance)
                {
                    shakeSpeed *= -1;
                }
            }

            shakeOffset.y += shakeSpeed * Time.deltaTime;
            transform.position = initialPosition + shakeOffset;
        }
    }


    public void StartShakeing()
    {
        isShaking = true;
        AudioManager.instance.PlaySound("GroundShakeSound");
    }


    public void StopShaking()
    {
        isShaking = false;
        transform.position = initialPosition;
    }













}
