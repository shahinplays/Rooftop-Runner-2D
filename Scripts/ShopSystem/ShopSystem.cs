using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    public GameObject[] characterSkins;
    public int currentIndex;

    public CharacterBluprint[] models;
    public Button buyButton;

    void Start()
    {

        foreach (CharacterBluprint model in models)
        {
            if (model.price == 0)
            {
                model.isUnlocked = true;
            }
            else
            {
                model.isUnlocked = PlayerPrefs.GetInt(model.name, 0) == 0 ? false : true;
            }
        }


        currentIndex = PlayerPrefs.GetInt("SelectCharacter", 0);

        foreach (GameObject skin in characterSkins)
        {
            skin.gameObject.SetActive(false);
        }
        characterSkins[currentIndex].SetActive(true);
    }




    void Update()
    {
        UpdateUi();
    }






    public void NextButton()
    {
        characterSkins[currentIndex].SetActive(false);
        currentIndex++;
        AudioManager.instance.PlaySound("ButtonClick");
        if (currentIndex >= characterSkins.Length)
        {
            currentIndex = 0;
        }
        characterSkins[currentIndex].SetActive(true);
        CharacterBluprint c = models[currentIndex];
        if (!c.isUnlocked) { return; }
        PlayerPrefs.SetInt("SelectCharacter", currentIndex);

    }


    public void PrivousButton()
    {
        characterSkins[currentIndex].SetActive(false);
        currentIndex--;
        AudioManager.instance.PlaySound("ButtonClick");
        if (currentIndex <= -1)
        {
            currentIndex = characterSkins.Length - 1;
        }
        characterSkins[currentIndex].SetActive(true);
        CharacterBluprint c = models[currentIndex];
        if (!c.isUnlocked) { return; }
        PlayerPrefs.SetInt("SelectCharacter", currentIndex);
    }




    public void UpdateUi()
    {
        CharacterBluprint c = models[currentIndex];
        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TMP_Text>().text = "Buy-" + c.price;
            if(c.price < PlayerPrefs.GetInt("NumberOfCoin"))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }

    }




    public void UnlockCharacter()
    {
        CharacterBluprint c = models[currentIndex];

        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectCharacter", currentIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoin", PlayerPrefs.GetInt("NumberOfCoin") - c.price);
        AudioManager.instance.PlaySound("ButtonClick");
    }







}
