using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
public class display_winner : MonoBehaviour
{
    // Start is called before the first frame update
    Text text;
    public Image BC, BCF, GC, GCF;
    GameObject game_set_background, game_set_background1, cam;
    public int round_score = 0, blue = 1;
    float time = 0f, span = 4.5f;
    string color, t;
    bool Green_half = false, Blue_half = false, game_set;
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        //Debug.Log(cam);
        text = GetComponent<Text>();
        game_set_background = GameObject.Find("win_display");
        game_set_background.SetActive(false);
        game_set_background1 = GameObject.Find("win_display (1)");
        BC.fillAmount = 0f;
        BCF.fillAmount = 0f;
        GC.fillAmount = 0f;
        GCF.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        game_win(); 
        time += Time.deltaTime;
        round_set();
        if (Green_half == true || Blue_half == true)
        {
            //BC.GetComponent<Green_circle>().circle_move();
            
        }
    }
    void game_win()
    {
        if ((round_score < 5 && round_score >= 0) && (color == "Green" || color == "Blue"))
        {
            //ȸ�� ��� �ø�
            game_set_background.SetActive(true);
            //color = �� ��� ��
            if (color == "Green" && Blue_half == false)
            {
                text.color = new Color(0, 0, 255);
                BC.fillAmount = 0.5f; BCF.fillAmount = 1f;
                text.text = "HALF BLUE";
            }
            else if (color == "Green" && Blue_half == true)
            {
                text.color = new Color(0, 0, 255);
                BC.fillAmount = 1f;
                BCF.fillAmount = 0f;
                t = "BRW";
                text.text = "ROUND BLUE";
            }
            else if (color == "Blue" && Green_half == false)
            {
                text.color = new Color(0, 0, 255);
                BC.fillAmount = 0.5f;
                BCF.fillAmount = 1f;
                text.text = "HALF GREEN";
            }
            else if (color == "Blue" && Green_half == true)
            {
                text.color = new Color(0, 0, 255);
                BC.fillAmount = 1f;
                BCF.fillAmount = 0f;
                t = "GRW";
                text.text = "ROUND GREEN";
            }
            else Debug.Log("Error");

            if (time >= 5)
            {
                Application.Quit();
            }
            
        }
    }
    void round_set()
    {
        float in_time = 0, in_span = 3.5f;
        if (time >= span)
        {
            if (in_time >= in_span)
            {
                game_set_background.SetActive(false); //ȸ�� ��� ����
                //�̱� ��� ���� ���� ���� Ʈ���Ű� �ߵ���
                if (color == "Green") Blue_half = true;
                else if (color == "Blue") Green_half = true;
                //���� Ʈ���Ű� �ߵ��� ���¿��� �� �� �� �� �̱�� ���� ��, ��� ���� �ʱ�ȭ
                else if ((Green_half == true || Blue_half == true) && (t == "GRW" || t == "BRW"))
                {
                    Green_half = false; Blue_half = false;
                    t = ""; round_score += 1;
                }
                time = 0; color = null;
                text.text = "";
            }
            in_time += Time.deltaTime;
        }
        else
        {
            if (game_set == true)
            {
                string a = cam.GetComponent<Cam_move>().camera_move();
                if (a == "end")
                {
                    game_set = false;
                    game_set_background1.SetActive(false);
                }
            }
        }
    }
    //���� �Ŵ����� �ش� ���� �¸����� ���� ������ 
    public void GameManager_Pass_Game_Winner(string winner_color)
    {
        this.color = winner_color; //�й����� ���� ����
        if (color != "") game_set = true;
    }
}
