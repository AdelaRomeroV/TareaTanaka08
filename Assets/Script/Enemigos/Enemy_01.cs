using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_01 : MonoBehaviour
{
    [Header("Movimiento")]

    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 dir;

    public int life;

    public float timer;
    public float maxTimer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirection();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            if(life <= 0 )
            {
                Destroy(gameObject);
            }
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            life--;
            if(life <= 0 )
            {
                Destroy(gameObject);
            }
        }
    }

    void Move()
    {
        rb2d.velocity = dir * speed;
    }

    void ChangeDirection()
    {
        timer += Time.deltaTime;

        if(timer >= maxTimer ) 
        {
            dir *= -1;
            timer = 0;
        }
    }
}
