using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    private bool shouldFall = true;
    public float fallSpeed = 2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (shouldFall)
        {
            Vector2 pos = transform.position;
            float fallAmount = fallSpeed * Time.fixedDeltaTime;
            pos.y -= fallAmount;
            transform.position = pos;
        }
    }
}
