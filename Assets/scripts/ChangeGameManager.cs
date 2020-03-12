using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGameManager : MonoBehaviour {

    public GameObject[] allPlayerObj;
    public GameMenu gameMenu;
    public Transform playerFather;
    public Transform npcFather;
    private GameObject nowShowPlayer;
    private GameObject nowShowNpc;
    private void OnEnable()
    {
         Init();
    }

    public void Init()
    {
        if (nowShowPlayer != null)
            Destroy(nowShowPlayer);
        if (nowShowNpc != null)
            Destroy(nowShowNpc);
         
        GameObject go = Instantiate(allPlayerObj[GameController._instance.NowUsePlayerID], playerFather, false) as GameObject;
        go.name = "Armature";
        nowShowPlayer = go;
        go.GetComponent<Animator>().Play(GameController._instance.animName[0]);
        go.GetComponent<Animator>().speed = GameController._instance.AnimSpeed;

        int nowNpcID = GameController._instance.GetNpcUse[GameController._instance.NowPlayLevel];
        int showNpcID = 0;
        if ( nowNpcID == GameController._instance.NowUsePlayerID)
        {
            showNpcID = nowNpcID + 1 > 19 ? nowNpcID - 1 : nowNpcID + 1;
        }
        else
        {
            showNpcID = nowNpcID;
        }
         
        GameObject goo = Instantiate(allPlayerObj[showNpcID], npcFather, false) as GameObject;

        UIManager._instance.gameMenu.GetComponent<GameMenu>().npcName.sprite = UIManager._instance.allName[showNpcID];
        UIManager._instance.gameMenu.GetComponent<GameMenu>().npcName.SetNativeSize();

        goo.name = "Armature";
        nowShowNpc = goo;
        goo.GetComponent<Animator>().Play(GameController._instance.animName[0]);
        goo.GetComponent<Animator>().speed = GameController._instance.AnimSpeed;

        grade.redgrade = 0;
        text.bluegrade = 0;
    }


    private void OnDisable()
    {
        if (nowShowPlayer != null)
            Destroy(nowShowPlayer);
        if (nowShowNpc != null)
            Destroy(nowShowNpc);
    }

    public void Des()
    {
        //if (nowShowPlayer != null)
        //    Destroy(nowShowPlayer);
        //if (nowShowNpc != null)
        //    Destroy(nowShowNpc);
    }
}
