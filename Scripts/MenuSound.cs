using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    
    void Start()
    {
        AudioManager.instance.StopSound("GameMusic");
        AudioManager.instance.PlaySound("IntroMusic");
    }

}
