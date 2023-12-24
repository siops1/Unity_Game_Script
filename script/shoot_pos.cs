using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_pos : MonoBehaviour
{
    public Vector3 ase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shoot_Instantiate(GameObject shoot, Vector3 pos, Quaternion rotation) //Instantiate(shoot, pos.position, transform.rotation);
    {
        Instantiate(shoot, pos, rotation);
    }
    public void Shoot_pos_pass(Vector3 pos, Vector3 scale)
    {
        transform.position = pos + ase;
        transform.localScale = scale;
    }
}
