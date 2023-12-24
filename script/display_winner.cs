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
            //회색 배경 올림
            game_set_background.SetActive(true);
            //color = 진 사람 색
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
                game_set_background.SetActive(false); //회색 배경 꺼짐
                //이긴 사람 색에 따라 하프 트리거가 발동됨
                if (color == "Green") Blue_half = true;
                else if (color == "Blue") Green_half = true;
                //하프 트리거가 발동된 상태에서 둘 중 한 명 이기면 라운드 끝, 모든 내용 초기화
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
    //게임 매니저가 해당 라운드 승리자의 색을 전달함 
    public void GameManager_Pass_Game_Winner(string winner_color)
    {
        this.color = winner_color; //패배자의 색이 들어옴
        if (color != "") game_set = true;
    }
}
