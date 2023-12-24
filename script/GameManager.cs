using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string color;
    public int num;
    bool player1_condition;
    GameObject display, player1, player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        display = GameObject.Find("round_winner");
    }

    // Update is called once per frame
    void Update()
    {   
        if (player1_condition == false)
        {
            display.GetComponent<display_winner>().GameManager_Pass_Game_Winner(color);
            color = null; player1_condition = true;
        }        
    }
    public void In_Game_Set(string color, bool t)
    {
        this.color = color;
        player1_condition = t;
    }
}
