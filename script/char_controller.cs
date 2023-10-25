using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
//using static UnityEditor.PlayerSettings;
using Unity.VisualScripting;

public class char_controller : NetworkBehaviour
{
    Rigidbody2D rigid2d;
    float move_speed = 2.0f, jump_speed = 400f;
    bool jump_trigger = false;
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
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
    }

    void move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 speed = new Vector2(move_speed, 0);
            rigid2d.AddForce(-speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector2 speed = new Vector2(move_speed, 0);
            rigid2d.AddForce(speed);
        }
        if ((Input.GetKey(KeyCode.Space) || (Input.GetKeyDown(KeyCode.W))) && jump_trigger == false)
        {
            Vector2 speed = new Vector2(0, jump_speed);
            rigid2d.AddForce(speed);
            jump_trigger = true;
        }
    }
}
