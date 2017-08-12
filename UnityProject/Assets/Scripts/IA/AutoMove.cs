using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{

    Vector3 move = Vector3.zero;
    public float speed = 10.0f;

    public State state;

    private void Start()
    {
        state = GetComponent<BallCollision>().state;
    }

    void Update()
    {
        float pos;
        if (state.Equals(GlobalInfo.instance.ball.state))
            pos = GlobalInfo.instance.ball.transform.position.x - transform.position.x;
        else
            pos = -GlobalInfo.instance.ball.transform.position.x - transform.position.x;
        if (pos > 0)
        {
            move.x = speed * Mathf.Min(pos, 1.0f);
        }
        if (pos < 0)
        {
            move.x = -(speed * Mathf.Min(-pos, 1.0f));
        }
        transform.position += move * Time.deltaTime;
    }

}
