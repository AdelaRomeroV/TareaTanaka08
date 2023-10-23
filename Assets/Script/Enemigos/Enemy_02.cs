using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02 : MonoBehaviour
{
    [Header("Movimiento")]
    public int life;

    private Rigidbody2D rb2d;
    public float speed;
    public Vector2 dir;

    public float timer;
    public float maxTimer;

    public float timerBullet;
    public float maxTimerBullet;
    public GameObject bulletEnemy;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        ChangeDirection();
        ShooterEnemy();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;

            if (life < 0)
            {
                Destroy(gameObject);
            }
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            life--;

            if(life < 0)
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

        if(timer >= maxTimer)
        {
            dir *= -1;
            timer = 0;
        }
    }

    void ShooterEnemy()
    {
        timerBullet += Time.deltaTime;

        if(timerBullet >= maxTimerBullet)
        {
            GameObject obj = Instantiate(bulletEnemy);
            obj.transform.position = transform.position;

            timerBullet = 0;

            for(int i = 0; i < 2; i++)
            { }
        }
    }
}
