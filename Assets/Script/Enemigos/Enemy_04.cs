using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy_04 : MonoBehaviour
{
    public float life;

    public float timerBullet;
    public float maxTimerBullet;
    public GameObject BulletEnemy;

    Vector2 iniPosition;

    void Start()
    {
        iniPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Vector2.zero;
        pos.x = Mathf.Cos(Time.time);
        pos.y = Mathf.Sin(Time.time);

        transform.position = iniPosition + pos;

        Shooter();
    }
    
    void Shooter()
    {
        timerBullet += Time.deltaTime;

        if(timerBullet > maxTimerBullet)
        {
            timerBullet = 0;

            Vector2 dir = new Vector2(1, 1);

            for(int i = 0; i < 3; i++) 
            {
                GameObject obj = Instantiate(BulletEnemy);
                obj.transform.position = transform.position;
                obj.GetComponent<BulletEnemy_04>().SetDirection(dir);
                dir.x -= 1;
            }
        }
    }
}
