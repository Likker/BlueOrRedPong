using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILife : MonoBehaviour
{

    public EPosition position;

    public void OnEnable()
    {
        Events.Instance.AddListener<OnPlayerLoseLifeEvent>(OnPlayerLoseLife);
        Events.Instance.AddListener<OnResetGameEvent>(OnResetGame);
    }

    public void OnDisable()
    {
        Events.Instance.RemoveListener<OnPlayerLoseLifeEvent>(OnPlayerLoseLife);
        Events.Instance.RemoveListener<OnResetGameEvent>(OnResetGame);
    }

    public void OnPlayerLoseLife(OnPlayerLoseLifeEvent e)
    {
        if (e.position.Equals(position) && transform.childCount > 0)
            Destroy(transform.GetChild(0).gameObject);
    }

    public void OnResetGame(OnResetGameEvent e)
    {

        while (transform.childCount > 0)
            DestroyImmediate(transform.GetChild(0).gameObject);
        Debug.Log(transform.childCount);
        for (int i = 0; i < SettingsManager.instance.MAX_LIFE; i++)
        {
            GameObject go = Instantiate(GlobalInfo.instance.LifePrefab);
            go.transform.parent = this.transform;
            go.transform.localScale = Vector3.one;
        }
    }
}