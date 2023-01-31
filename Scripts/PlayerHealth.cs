using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    // player Health
    public int health = 3;
    public TMP_Text healthText;

    public Image damageScreen;
    private bool damaged = false;
    private Color damageColor = new Color(1, 0, 0, 0.5f);
    private float smoothColor = 5f;

    void Update()
    {
        healthText.text = health.ToString();

        if (damaged)
        {
            damageScreen.color = damageColor;
            AudioManager.instance.PlaySound("PlayerHurt");
        }
        else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColor * Time.deltaTime);
        }
        
        damaged = false;
    }


    public void PlayerGetDamage(int damage)
    {
        damaged = true;
        health -= damage;
        
        healthText.text = health.ToString();
        if (health <= 0)
        {
            gameObject.SetActive(false);
            UIManager.instance.gameOverPanal.SetActive(true);
            AudioManager.instance.PlaySound("GameOverSound");
            Time.timeScale = 0;
        }
    }
}
