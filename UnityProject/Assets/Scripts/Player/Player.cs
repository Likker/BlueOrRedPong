using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public struct RacketInfo
{
    public EPosition position;
    public GameObject inputCollider;
    public GameObject racket;
}

public class Player
{
    public int Life = 3;

    public Player()
    {
        Life = SettingsManager.instance.MAX_LIFE;
    }
}
