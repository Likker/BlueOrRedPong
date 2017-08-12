using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    public GameObject UIMenu;
    public GameObject UIGame;

    public GameObject mainMenu;
    public GameObject rules;

    public void StartVSPlayer()
    {
        SettingsManager.instance.mode = EMode.PVP;
        UIGame.SetActive(true);
        GameManager.instance.Reset();
        
        UIMenu.SetActive(false);
    }

    public void StartVSAI()
    {
        SettingsManager.instance.mode = EMode.IA;
        UIGame.SetActive(true);
        GameManager.instance.Reset();     
        UIMenu.SetActive(false);
    }

    public void ReadRules()
    {
        mainMenu.SetActive(false);

        rules.SetActive(true);
    }

    public void QuitRules()
    {
        mainMenu.SetActive(true);
        rules.SetActive(false);
    }

    public void BackToMainMenu()
    {
        UIMenu.SetActive(true);
        rules.SetActive(false);
        UIGame.SetActive(false);
    }
}
