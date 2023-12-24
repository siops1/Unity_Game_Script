using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string camera_move()
    {
        if (transform.position.x >= 51)
        {
            return "end";
        }
        else
        {
            transform.position += new Vector3(2.1f, 0);
        }
        return "0";
    }
}
