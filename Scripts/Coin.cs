using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject impactEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound("CoinPickSound");
            Scores.instance.numberOfCoin++;
            PlayerPrefs.SetInt("NumberOfCoin", Scores.instance.numberOfCoin);
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }


}
