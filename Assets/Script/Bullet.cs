using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float speed;
    private Rigidbody2D rb2d;
    public int damage;
    
    [SerializeField]
    private Vector2 direccion;

    public void direcion(Vector2 vale)
    { 
        direccion = vale;
    }

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = (direccion * speed);
    }
}
