using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char_shoot : MonoBehaviour
{
    public GameObject shoot;
    public Transform pos;
    public GameObject player;
    float c = 0.35f, z;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 len = Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.transform.position;
        z = Mathf.Atan2(len.y, len.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, z);
        if (player.transform.position.x <= mouse.x)
        {
            transform.position = player.transform.position + new Vector3(Mathf.Cos(Mathf.PI / 180 * z) * c, Mathf.Sin(Mathf.PI / 180 * z) * c, 0); ; ;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (player.transform.position.x >= mouse.x)
        {
            pos.transform.position = player.transform.position + new Vector3(Mathf.Cos(Mathf.PI / 180 * z) * c, Mathf.Sin(Mathf.PI / 180 * z) * c, 0);
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
            if (Input.GetMouseButtonDown(0))
        {
            Instantiate(shoot, pos.position, transform.rotation);
        }
    }
}
