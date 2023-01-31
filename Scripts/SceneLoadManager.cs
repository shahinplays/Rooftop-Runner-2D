using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoadManager : MonoBehaviour
{
    
    public void GameScene()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void MenuScene()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        SceneManager.LoadScene(0);
    }


    public void ShopScene()
    {
        SceneManager.LoadScene(1);
        AudioManager.instance.PlaySound("ButtonClick");
    }


    public void PauseGame()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        Time.timeScale = 0;
        UIManager.instance.pausePanal.SetActive(true);
    }


    public void ResumeGame()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        UIManager.instance.pausePanal.SetActive(false);
        Time.timeScale = 1;
    }


    public void ReStartGame()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }



    public void GameQuit()
    {
        AudioManager.instance.PlaySound("ButtonClick");
        Application.Quit();
    }






}
