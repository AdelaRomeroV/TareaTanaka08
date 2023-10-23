using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy_04 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private Vector2 dir;

    public void SetDirection(Vector2 direct)
    {
        dir = direct;
    }
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Destroy(gameObject, 2f);
    }

    void Move()
    {
        rb2d.velocity = dir * speed;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
