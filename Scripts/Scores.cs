using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scores : MonoBehaviour
{
    public static Scores instance;

    public TMP_Text coinText;
    [HideInInspector]public int numberOfCoin;

    public TMP_Text distanceText;
    [HideInInspector]public float distance;
    
    void Awake()
    {
        instance = this;    
    }


    void Start()
    {
        numberOfCoin = PlayerPrefs.GetInt("NumberOfCoin", 0);
    }




    private void Update()
    {
        coinText.text = numberOfCoin.ToString();
    }










}
