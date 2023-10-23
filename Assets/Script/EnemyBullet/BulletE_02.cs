using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletE_02 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 dir;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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
