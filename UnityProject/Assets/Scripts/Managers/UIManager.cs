using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public GameObject TapToPlay;

    public GameObject EndGameUI;
    public Text TopText;
    public Text BottomText;

    private void OnEnable()
    {
        Events.Instance.AddListener<OnInitializeGameEvent>(OnInitGame);
        Events.Instance.AddListener<OnStartGameEvent>(OnStartGame);
        Events.Instance.AddListener<OnEndGameEvent>(OnEndGame);
    }

    private void OnDisable()
    {
        Events.Instance.RemoveListener<OnInitializeGameEvent>(OnInitGame);
        Events.Instance.RemoveListener<OnStartGameEvent>(OnStartGame);
        Events.Instance.RemoveListener<OnEndGameEvent>(OnEndGame);
    }

    public void OnInitGame(OnInitializeGameEvent e)
    {
        TapToPlay.SetActive(true);
        EndGameUI.SetActive(false);
    }

    public void OnStartGame(OnStartGameEvent e)
    {
        TapToPlay.SetActive(false);
    }

    public void OnEndGame(OnEndGameEvent e)
    {
        EndGameUI.SetActive(true);
        if (e.loser == EPosition.TOP)
        {
            TopText.text = "A LOSER IS YOU";
            BottomText.text = "A WINNER IS YOU";
        }
        else
        {
            TopText.text = "A WINNER IS YOU";
            BottomText.text = "A LOSER IS YOU";
        }
    }
}
