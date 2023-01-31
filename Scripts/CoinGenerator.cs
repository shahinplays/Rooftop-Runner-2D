using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject[] coins;

    void Start()
    {
        StartCoroutine(waitAndSpwanCoin());
    }


    private void CoinGenarate()
    {
        int randomCoin = Random.Range(0, coins.Length);
        float pos = Random.Range(-5, 12f);
        GameObject coinSpw = Instantiate(coins[randomCoin], transform.position + new Vector3(0, pos, 0), transform.rotation);
        coinSpw.transform.SetParent(transform);

        StartCoroutine(waitAndSpwanCoin());
    }



    IEnumerator waitAndSpwanCoin()
    {
        yield return new WaitForSeconds(5f);
        CoinGenarate();
    }

}
