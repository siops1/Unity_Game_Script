using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green_circle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void circle_move()
    {
        if (transform.localScale.x == 0.3f && transform.localScale.y == 0.3f)
        {
            if (transform.position.x <= -690 && transform.position.y >= 618)
            {
                Debug.Log("STOP");
            }
            else
            {
                transform.position += new Vector3(3f, 2.686f);
            }
        }
        else
        {
            transform.localScale += new Vector3(-0.3f, -0.3f);
        }
        
    }
}
