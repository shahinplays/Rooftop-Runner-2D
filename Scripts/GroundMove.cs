using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float speed = 1;


    CameraControler cameraShak;

    void Start()
    {
        cameraShak = GameObject.Find("Main Camera").GetComponent<CameraControler>();
    }


    void FixedUpdate()
    {

        transform.Translate(Vector2.left * speed * Time.fixedDeltaTime);
      
        if (transform.position.x <= -90 || transform.position.y <= -30f)
        {
            cameraShak.StopShaking();
            Destroy(this.gameObject);
        } 
    }
}
