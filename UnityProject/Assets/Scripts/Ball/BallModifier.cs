using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallModifier : MonoBehaviour
{

    public State state;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            GlobalInfo.instance.ball.state = state;
            GlobalInfo.instance.ball.UpdateState();
        }
    }
}
