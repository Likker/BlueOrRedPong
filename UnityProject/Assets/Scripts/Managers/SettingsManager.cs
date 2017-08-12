using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EMode
{
    PVP,
    IA
}

public class SettingsManager : MonoSingleton<SettingsManager>
{

    public EMode mode = EMode.PVP;
    public int MAX_PLAYERS = 2;
    public int MAX_LIFE = 3;
}
