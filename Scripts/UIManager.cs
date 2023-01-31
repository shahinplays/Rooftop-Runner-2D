using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject gameOverPanal;
    public GameObject pausePanal;
    public Transform player;

    void Awake()
    {
        instance = this;    
    }


    void Update()
    {
        Scores.instance.coinText.text = Scores.instance.numberOfCoin.ToString();

        if (!player.gameObject.activeInHierarchy || pausePanal.gameObject.activeInHierarchy) { return; }
        else
        {
            Scores.instance.distance += 0.01f;
            Scores.instance.distanceText.text = Scores.instance.distance.ToString("0") + "m";
        }
    }










}
