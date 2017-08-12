using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    BLUE,
    RED
}

public class Ball : MonoBehaviour
{

    private float speed = 30;
    public float beginSpeed = 70;
    public float MaxSpeed = 120;
    public State state;
    public ParticleSystem particles;

    private Material mat;
    private TrailRenderer trailRender;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        Events.Instance.AddListener<OnStartGameEvent>(OnStartGame);
        Events.Instance.AddListener<OnEndGameEvent>(OnEndGame);
    }

    private void OnDisable()
    {
        Events.Instance.RemoveListener<OnStartGameEvent>(OnStartGame);
    }

    public void OnEndGame(OnEndGameEvent e)
    {
        rb.velocity = Vector2.zero;
    }

    public void OnStartGame(OnStartGameEvent e)
    {
        speed = beginSpeed;

        rb.velocity = new Vector2(0.5f, 1) * speed;
    }

    public void IncreaseSpeed()
    {
        if (speed < MaxSpeed)
        {
            speed += 2f;
            rb.AddForce(transform.forward * speed, ForceMode2D.Impulse);
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mat = GetComponent<Renderer>().material;
        trailRender = GetComponent<TrailRenderer>();
        UpdateState();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        particles.Play();
        if (col.gameObject.tag == "Player")
        {
            float x = hitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.x);
            Vector2 dir = new Vector2(x, transform.localPosition.y > 0 ? -1 : 1).normalized;
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketLength)
    {
        return (ballPos.x - racketPos.x) / racketLength;
    }

    public void UpdateState()
    {
        switch (state)
        {
            case State.BLUE:
            mat.color = GlobalInfo.instance.BlueColor;
            trailRender.startColor = GlobalInfo.instance.BlueColor;
            break;
            case State.RED:
            mat.color = GlobalInfo.instance.RedColor;
            trailRender.startColor = GlobalInfo.instance.RedColor;
            break;
        }
    }
}
