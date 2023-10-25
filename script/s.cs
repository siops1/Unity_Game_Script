using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    bool live = true;
    public float speed = 8f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
        if (live == false)
        {
            Destroy(gameObject);
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
    }
}
