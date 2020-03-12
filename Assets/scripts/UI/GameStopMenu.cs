using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStopMenu : MonoBehaviour {

   // public Button btn_close;
    public Button btn_ok;
    public Button btn_no;


    void Start()
    {
       // btn_close.onClick.AddListener(CloseClick);
        btn_ok.onClick.AddListener(OkClick);
        btn_no.onClick.AddListener(NoClick);
    }

    void Update()
    {

    }

    void CloseClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameController._instance.isstart = true;
        UIManager._instance.ShowOrHideGameStop(false);
        UIManager._instance.uiStep = UIManager.UIStep.game;
        GameController._instance.player.transform.localPosition = new Vector3(GameController._instance.player.transform.localPosition.x, GameController._instance.player.transform.localPosition.y, 5);
        GameController._instance.npc.transform.localPosition = new Vector3(GameController._instance.npc.transform.localPosition.x, GameController._instance.npc.transform.localPosition.y, 5);
        GameController._instance.ballF.SetActive(true);

          GameController._instance.Ball.GetComponent<Rigidbody2D>().velocity = GameController._instance.vel;
        GameController._instance.isStop = false ;
    }
    void OkClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameController._instance.isstart = true;
        UIManager._instance.ShowOrHideGameStop(false);
        UIManager._instance.uiStep = UIManager.UIStep.game;
        GameController._instance.player_script.StopPlay(false );
        GameController._instance.npc.GetComponent<Npc>().StopPlay(false ); 
        GameController._instance.isStop = false;
        GameController._instance.StopBallOver();
        GameController._instance.leftLankuang.StopPlay(false );
        GameController._instance.rightLankuang.StopPlay(false );
    }
    void NoClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        GameController._instance.JishiTime = 0;
        GameController._instance.ShowTime = 59;
        GameController._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideStart(true);
        UIManager._instance.ShowOrHideGame(false);
        UIManager._instance.ShowOrHideGameStop(false);
        UIManager._instance.uiStep = UIManager.UIStep.start;
       
        //更换背景音乐
        UIManager._instance.audioManager.PlayBG(Random.Range(0,2));
         
        GameController._instance.isStop = false;
    }
}
