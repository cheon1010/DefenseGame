using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPScript : MonoBehaviour
{
    public float CreateTime = 0.5f;
    public float speed = 0.2f;
    public float deleteTime = 5f;
    public float MoveTime = 1.0f;
    public Vector2 vel = Vector2.zero;
    public bool IsMove = false;
    public bool IsDelete = false;

    GameObject Magnet;
    private void Awake()
    {
        Magnet = GameObject.Find("MAGNET");
    }

    private void Update()
    {
        CreateTime += Time.deltaTime;
        if (CreateTime >= MoveTime)
            IsMove = true;

        if (CreateTime >= deleteTime)
            IsDelete = true;

        if(IsMove)
        {
            transform.position = Vector2.SmoothDamp(gameObject.transform.position, Magnet.transform.position, ref vel, speed);
         }
        if (IsDelete)
            Destroy(gameObject);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Magnet")
        {
            GameManager.instance.Mana += 1;
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            gameObject.transform.position = new Vector3(-5.5f, 1, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            gameObject.transform.position = new Vector3(-5.5f, 1, 0);
        }
    }

    void ExpToMagnet()
    {
        if (gameObject.transform.position == Magnet.transform.position)
        {
            GameManager.instance.Mana += 1;
            Destroy(gameObject);
        }
    }
}
