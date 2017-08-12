using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerLoseLifeEvent : GameEvent
{
    public EPosition position;
}

public class BallCollision : MonoBehaviour
{

    public EPosition position;
    public State state;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            Debug.Log("COLLISION");

            if (GlobalInfo.instance.ball.state != state)
            {
                Events.Instance.Raise(new OnPlayerLoseLifeEvent() { position = position });
                Debug.Log("REMOVE A LIFE");
                GameManager.instance.players[position].Life -= 1;
                if (GameManager.instance.players[position].Life <= 0)
                    Events.Instance.Raise(new OnEndGameEvent() { loser = position });
            }
            else
            {
                // Increment speed of the ball;
                
                    GlobalInfo.instance.ball.IncreaseSpeed();
            }

        }
    }
}