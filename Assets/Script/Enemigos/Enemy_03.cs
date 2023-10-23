using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_03 : MonoBehaviour
{
    public float life;

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

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeDirection();
        shooter();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            life--;
            if(life < 0) { Destroy(gameObject); }
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            life--;
            if(life <= 0) { Destroy(gameObject); }
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

    void shooter()
    {
        timerBullet += Time.deltaTime;
        if(timerBullet >= maxTimerBullet)
        {
            timerBullet = 0;

            Vector2 direct = new Vector2(1, 0);
            for(int i = 0; i < 2; i++)
            {
                GameObject obj = Instantiate(bulletEnemy);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletEnemy_03>().SetDirection(direct);
                direct *= -1;
            }
        }
    }


}
