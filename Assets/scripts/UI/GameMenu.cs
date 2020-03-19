using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
    public Button btn_Home;
    public Button btn_tiao;
    public Button btn_qiang;
    public Text time;
    public GameObject panelStop;
    public Image playerName;
    public Image npcName;

   
    private void OnEnable()
    {
       // playerName.sprite = UIManager._instance.allName[GameController._instance.NowUsePlayerID];
        playerName.SetNativeSize();
        

     //   GameController._instance.isStop = false ;
        time.text = "59";
    }
    void Start()
    {
        btn_Home.onClick.AddListener(HomeClick);
        btn_tiao.onClick.AddListener(TiaoClick);
        btn_qiang.onClick.AddListener(QiangClick);

    }
    private void Update()
    { 
        if (GameController._instance.ShowTime < 10)
        {
            time.text ="0"+ GameController._instance.ShowTime.ToString();
        }
        else if(GameController._instance.ShowTime == 60)
        {
            time.text = "59";
        }
        else
        {
            time.text = GameController._instance.ShowTime.ToString();
        }

        if (UIManager._instance.uiStep == UIManager.UIStep.game)
        {
            if(GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled == true)
               GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled = false;
        }
        else
        {
            if (GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled == false)
                GameController._instance.hand.transform.Find("hand").GetComponent<Image>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TiaoClick();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            QiangClick();
        }
    }
    void HomeClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameController._instance.isstart = false;
        UIManager._instance.ShowOrHideGameStop(true);
        UIManager._instance.uiStep = UIManager.UIStep.gameStop;
        GameController._instance.player_script.StopPlay(true);
        GameController._instance.npc.GetComponent<Npc>().StopPlay(true);
        GameController._instance.isStop = true;
        GameController._instance.StopBall();
        GameController._instance.leftLankuang.StopPlay(true);
        GameController._instance.rightLankuang.StopPlay(true);
    }

    void TiaoClick()
    {
         
        GameController._instance.player_script.Tiao();
    }

    void QiangClick()
    {
        if (GameController._instance.isstart == false) return;
        if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
        {
            if (GameController._instance.isCanQiangDuan == true)
            {
                int a = Random.Range(0, 100);
                if (a < GameController._instance.playerAllValue[GameController._instance.NowUsePlayerID,5]/100)
                {//抢成功
                    GameController._instance.player_script.QiangDao();
                }
                else
                {//没抢到

                }
            }
        }
    }
}
