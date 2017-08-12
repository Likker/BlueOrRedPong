using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnResetGameEvent : GameEvent { }
public class OnInitializeGameEvent : GameEvent { }
public class OnStartGameEvent : GameEvent { }
public class OnEndGameEvent : GameEvent { public EPosition loser; }


public class GameManager : MonoSingleton<GameManager>
{
    public List<RacketInfo> playersRacket;
    public Dictionary<EPosition, Player> players = new Dictionary<EPosition, Player>();

    private void OnEnable()
    {
        Events.Instance.AddListener<OnEndGameEvent>(OnEndGame);
    }

    private void OnDisable()
    {
        Events.Instance.RemoveListener<OnEndGameEvent>(OnEndGame);
    }

    public void OnEndGame(OnEndGameEvent e)
    {
        for (int i = 0; i < playersRacket.Count; i++)
        {
            playersRacket[i].inputCollider.GetComponent<Collider2D>().enabled = false;
        }
    }

    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        Initialize();
        Events.Instance.Raise(new OnResetGameEvent());     
    }


    public void StartGame()
    {
        Events.Instance.Raise(new OnStartGameEvent());
    }

    public void Initialize()
    {
        InitializePlayers();
        InitializeMode();
        Events.Instance.Raise(new OnInitializeGameEvent());
    }

    private void InitializePlayers()
    {
        players.Clear();
        for (int i = 0; i < playersRacket.Count; i++)
        {
            players.Add(playersRacket[i].position, new Player());
        }
    }

    private void InitializeMode()
    {
        switch (SettingsManager.instance.mode)
        {
            case EMode.PVP:
            {
                for (int i = 0; i < playersRacket.Count; i++)
                {
                    SetPlayer(i);
                }
                break;
            }
            case EMode.IA:
            {
                for (int i = 0; i < playersRacket.Count; i++)
                {
                    if (playersRacket[i].position == EPosition.TOP)
                        SetIA(i);
                    else
                        SetPlayer(i);

                }
                break;
            }
        }
    }

    private void SetPlayer(int index)
    {
        playersRacket[index].inputCollider.GetComponent<Collider2D>().enabled = true;
        playersRacket[index].racket.GetComponent<AutoMove>().enabled = false;
    }

    private void SetIA(int index)
    {
        playersRacket[index].inputCollider.GetComponent<Collider2D>().enabled = false;
        playersRacket[index].racket.GetComponent<AutoMove>().enabled = true;
    }
}
