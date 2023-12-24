using UnityEngine;

public class Player1_hpbar : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject F, GM;
    public int s = 35, t = 6;
    void Start()
    {
        F = transform.parent.gameObject;
        transform.localScale = new Vector3(s, t, 0);
        GM = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = F.transform.position + new Vector3(0, 0.4f, 0);
        if (s <= 0)
        {
            //Debug.Log("Game Set");
            GM.GetComponent<GameManager>().In_Game_Set("Green", false);
        }
    }
    public void scale(int damage)
    {
        s = s - damage;
        transform.localScale = new Vector3(s, t, 0);
    }
    
}
