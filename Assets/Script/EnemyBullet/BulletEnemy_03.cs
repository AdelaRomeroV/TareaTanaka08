using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy_03 : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    public Vector2 dir;

    public void SetDirection(Vector2 Direct)
    {
        dir = Direct;
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = dir * speed;
        Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
