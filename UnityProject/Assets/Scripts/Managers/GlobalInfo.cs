using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInfo : MonoSingleton<GlobalInfo>
{
    public Camera mainCamera;
    public Ball ball;

    public Color32 RedColor;
    public Color32 BlueColor;

    public GameObject LifePrefab;
}

