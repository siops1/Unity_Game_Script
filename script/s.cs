using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    bool live = true;
    public float speed = 8f;
    float span = 10.0f, time = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        time += Time.deltaTime;
        if (live == false)
        {
            Destroy(gameObject);
        }

        if (time >= span)
        {
            time = 0;
            live = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("map_tile"))
        {
            live = false;
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            live = false;
        }
        if (collision.gameObject.CompareTag("player1"))
        {
            live = false;
        }
        if (collision.gameObject.CompareTag("player2"))
        {
            live = false;    
        }
    }
}
