using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
//using static UnityEditor.PlayerSettings;
using Unity.VisualScripting;

public class Player2_controller : NetworkBehaviour
{
    Rigidbody2D rigid2d;
    public float jump_speed = 400f;
    bool jump_trigger = false;
    public int damage = 2;
    GameObject C1;
    public Vector2 speed = new Vector2(4f, 0);
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
        C1 = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("map_tile"))
        {
            jump_trigger = false;
        }
        if (collision.gameObject.CompareTag("player1_shoot"))
        {
            C1.GetComponent<Player1_hpbar>().scale(damage);
        }
    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-(speed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime);
        }
        if ((Input.GetKey(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) && jump_trigger == false)
        {
            Vector2 speed = new Vector2(0, jump_speed);
            rigid2d.AddForce(speed);
            jump_trigger = true;
        }
    }
}
