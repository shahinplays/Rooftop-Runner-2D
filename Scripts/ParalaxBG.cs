using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxBG : MonoBehaviour
{
    public float speed = 1;

    public float lastPos;
    public float startPos;

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);

        if (transform.position.x <= lastPos) 
        {
            transform.position = new Vector2(startPos, transform.position.y); 
        }

    }



}
