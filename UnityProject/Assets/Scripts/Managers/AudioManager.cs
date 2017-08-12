using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoSingleton<AudioManager> {

    public AudioSource MusicMenu;
    public AudioSource MusicGame;


    private void OnEnable()
    {
        Events.Instance.AddListener<OnStartGameEvent>(OnStartGame);
        Events.Instance.AddListener<OnEndGameEvent>(OnEndGame);
    }

    private void OnDisable()
    {
        Events.Instance.RemoveListener<OnStartGameEvent>(OnStartGame);
        Events.Instance.RemoveListener<OnEndGameEvent>(OnEndGame);
    }

    public void OnStartGame(OnStartGameEvent e)
    {
        MusicMenu.Stop();
        MusicGame.Play();
    }

    public void OnEndGame(OnEndGameEvent e)
    {
        MusicMenu.Play();
        MusicGame.Stop();
    }
}
