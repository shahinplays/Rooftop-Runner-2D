using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpwaner : MonoBehaviour
{
    public GameObject[] grounds;
    public float spwanTimer = 1f;
    
    CameraControler camreaShake;

    void Start()
    {
        StartCoroutine(SpwanCoroten());
        camreaShake = GameObject.Find("Main Camera").GetComponent<CameraControler>();
    }

    private void GroundSpwan()
    {
        // Ground Spwan 
        int groundIndex = Random.Range(0, grounds.Length);
        int randomPos = Random.Range(-12, -20);
        GameObject go = Instantiate(grounds[groundIndex], transform.position + new Vector3(0, randomPos, 0), transform.rotation);
        go.transform.SetParent(transform);

        // ground fall
        if (Random.Range(0, 5) == 3)
        {
            GroundFall fall = go.AddComponent<GroundFall>();
            camreaShake.StartShakeing();
        }

        StartCoroutine(SpwanCoroten());
    }


    IEnumerator SpwanCoroten()
    {
        yield return new WaitForSeconds(spwanTimer);
        GroundSpwan();
    }
}
