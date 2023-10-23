using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private Rigidbody2D rb2d;

    [Header("Disparo")]
    private float shooterTimer;
    private float shooterDeLayTime;
    private Vector2 direcion;

    public GameObject bullet;
    public GameObject bulletUlti;

    public float life;

    void Awake() //Lo importante
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        timer();
        shooter();
        ulti();
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        if(horizontal != 0 || vertical != 0)
        {
            direcion = new Vector2(horizontal, vertical);

        }

        rb2d.velocity = new Vector2(horizontal, vertical) * speed;
    }
    void timer()
    {
        shooterTimer += Time.deltaTime;
    }

    void shooter()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shooterTimer >= shooterDeLayTime)
        {
            GameObject obj = Instantiate(bullet);
            obj.transform.position = transform.position;
            shooterTimer = 0;
            obj.GetComponent<Bullet>().direcion(direcion);
        }
    }

    void ulti()
    {
       if(Input.GetKeyDown(KeyCode.Q) && shooterTimer >= shooterDeLayTime)
        {
            GameObject obj = Instantiate(bulletUlti);
            obj.transform.position = transform.position;
            shooterTimer = 0;
            obj.GetComponent<Bullet>().direcion(direcion);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("BulletEnemy"))
        {
            life -=collision.gameObject.GetComponent<Damage>().damage;
            Destroy(collision.gameObject);

            if(life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
