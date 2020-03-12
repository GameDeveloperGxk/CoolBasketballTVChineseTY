using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class UISelect : MonoBehaviour
{


    public StartMenu startMenu;
    public CloseMenu closeMenu;
    public SelectPlayerMenu selectPlayerMenu;
    public SelectLevelMenu selectLvMenu;
    public GameMenu gameMenu;
    public GameStopMenu stopMenu;
    public GameOver gameOver;

    private Transform mtra;
    private Button[] allBtn;
    float timer = 0;
    bool isHaveClick = false;
    void Start()
    {
        mtra = transform;
        LeanTween.scale(gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.3f).setLoopPingPong();
        mtra.position = startMenu.btn_start.transform.position;
        allBtn = new Button[] {startMenu.btn_start, startMenu.btn_sound, startMenu.btn_close,  //0  1  2
        closeMenu.btn_ok,closeMenu.btn_no,                                                     //3  4
        selectPlayerMenu.btn_Home,selectPlayerMenu.btn_Play,selectPlayerMenu.btn_1,selectPlayerMenu.btn_2,selectPlayerMenu.btn_3,   // 5  6  7  8  9
        selectPlayerMenu.btn_4,selectPlayerMenu.btn_5,selectPlayerMenu.btn_6,selectPlayerMenu.btn_7,selectPlayerMenu.btn_8,         //10  11 12 13 14
        selectPlayerMenu.btn_9,selectPlayerMenu.btn_10,selectPlayerMenu.btn_11,selectPlayerMenu.btn_12,selectPlayerMenu.btn_13,     //15  16 17 18 19
        selectPlayerMenu.btn_14,selectPlayerMenu.btn_15,selectPlayerMenu.btn_16,selectPlayerMenu.btn_17,selectPlayerMenu.btn_18,selectPlayerMenu.btn_19,selectPlayerMenu.btn_20,  // 20---26
        selectLvMenu.btn_Home,selectLvMenu.btn_Left,selectLvMenu.btn_Right,selectLvMenu.levelBtnAll[0],selectLvMenu.levelBtnAll[1],selectLvMenu.levelBtnAll[2],                   // 27---32
        selectLvMenu.levelBtnAll[3],selectLvMenu.levelBtnAll[4],selectLvMenu.levelBtnAll[5],selectLvMenu.levelBtnAll[6],selectLvMenu.levelBtnAll[7],selectLvMenu.levelBtnAll[8],  // 33---38
        selectLvMenu.levelBtnAll[9],selectLvMenu.levelBtnAll[10],selectLvMenu.levelBtnAll[11],selectLvMenu.levelBtnAll[12],selectLvMenu.levelBtnAll[13],selectLvMenu.levelBtnAll[14],   // 39 ---44
        selectLvMenu.levelBtnAll[15],selectLvMenu.levelBtnAll[16],selectLvMenu.levelBtnAll[17],selectLvMenu.levelBtnAll[18],selectLvMenu.levelBtnAll[19],selectLvMenu.levelBtnAll[20],  // 45---50
        selectLvMenu.levelBtnAll[21],selectLvMenu.levelBtnAll[22],selectLvMenu.levelBtnAll[23],selectLvMenu.levelBtnAll[24],selectLvMenu.levelBtnAll[25],selectLvMenu.levelBtnAll[26],  //51---56
        selectLvMenu.levelBtnAll[27],selectLvMenu.levelBtnAll[28],selectLvMenu.levelBtnAll[29],           //57---59
        gameMenu.btn_Home,                                            //60 
        stopMenu.btn_ok, stopMenu.btn_no,                            // 61  62
        gameOver.btnHome, gameOver.btnRes, gameOver.btnPlay,       // 63  64   65
        selectPlayerMenu.buy,selectPlayerMenu.noBuy};
    }

    void Update()
    {
        ClickFangxiang();
        ClickSure();
        ClickReturn();
        if (isHaveClick == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                timer = 0;
                isHaveClick = false;
            }
        }
    }

    public KeyCode SureKey()
    {
        KeyCode DPAD_CENTER = (KeyCode)10;
        return DPAD_CENTER;
    }
    void ClickOK(Button btn)
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(SureKey()))
        {
            btn.onClick.Invoke();          //即可自动产生点击动作并调用方法。
        }
    }

    void ClickBack(Button btn)
    {
        // if (Input.GetKeyDown(KeyCode.Escape))
        // {
        btn.onClick.Invoke();          //即可自动产生点击动作并调用方法。
                                       // }
    }
    void ClickSure()
    {
        if (isHaveClick == false)
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(SureKey()))
            {
               // print("?????"  + selectLvMenu.levelBtnAll[selectLvMenu.GetLevelData].transform.localPosition +"                 "+mtra.localPosition);
                isHaveClick = true;
                for (int i = 0; i < allBtn.Length; i++)
                {
                    if (mtra.position == allBtn[i].transform.position)
                    {
                       // print("??????????" + i);
                        if (UIManager._instance.uiStep == UIManager.UIStep.start)
                        {
                            if (i == 0)
                            {//开始界面跳转选人界面
                                mtra.position = selectPlayerMenu.btn_1.transform.position;
                            }
                            else if (i == 2)
                            {//开始界面跳转关闭界面
                                mtra.position = closeMenu.btn_ok.transform.position;
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        }
                        else if (UIManager._instance.uiStep == UIManager.UIStep.close)
                        {
                            if (i == 4)
                            {//关闭界面跳转开始界面
                                mtra.position = startMenu.btn_start.transform.position;
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        }
                        else if (UIManager._instance.uiStep == UIManager.UIStep.selectPlayer)
                        {
                            if (i == 5)
                            {//选人界面跳转开始界面
                                mtra.position = startMenu.btn_start.transform.position;
                            }
                            else if (i == 6)
                            {//选人界面跳转选关界面
                              //  mtra.position = selectLvMenu.levelBtnAll[selectLvMenu.GetLevelData].transform.position;
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        }
                        else if (UIManager._instance.uiStep == UIManager.UIStep.selectLevel)
                        {
                            if (i == 27)
                            {//选关界面跳转开始界面
                                mtra.position = startMenu.btn_start.transform.position;
                            }
                            else if (i >= 30 && i <= 59)
                            {//选关界面跳转游戏界面 
                               // if (i -30 <= selectLvMenu.GetLevelData)
                                //    mtra.position = gameMenu.btn_Home.transform.position;
                            }
                            else if (i == 28)
                            {//28 left
                                if (selectLvMenu.GetMenuID == 1)
                                {
                                    mtra.position = selectLvMenu.levelBtnAll[10].transform.position;
                                }
                            }
                            else if (i == 29)
                            {// 29  right
                                if (selectLvMenu.GetMenuID == 1)
                                {
                                    mtra.position = selectLvMenu.levelBtnAll[10].transform.position;
                                }
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        } 
                        else if (UIManager._instance.uiStep == UIManager.UIStep.game)
                        {
                            if (i == 60)
                            {//游戏界面跳转到暂停界面
                               // mtra.position = stopMenu.btn_ok.transform.position;
                            }
                           // allBtn[i].onClick.Invoke();
                            return;
                        } 
                        else if (UIManager._instance.uiStep == UIManager.UIStep.gameStop)
                        {
                            if (i == 61)
                            {//暂停界面跳转到游戏界面
                                mtra.position = gameMenu.btn_Home.transform.position;
                            }
                            else
                            if (i == 62)
                            {//暂停界面跳转到开始界面
                                mtra.position = startMenu.btn_start.transform.position;
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        } 
                        else if (UIManager._instance.uiStep == UIManager.UIStep.gameOver)
                        {
                            if (i == 63)
                            {//结束界面跳转到开始界面
                                mtra.position = startMenu.btn_start.transform.position;
                            }
                            else if (i == 64)
                            {//结束界面跳转到游戏界面
                                mtra.position = gameMenu.btn_Home.transform.position;
                            }
                            else if (i == 65)
                            {//结束界面跳转到选关界面
                             //   mtra.position = selectLvMenu.levelBtnAll[selectLvMenu.GetLevelData].transform.position;
                            }
                            allBtn[i].onClick.Invoke();
                            return;
                        }
                        else if (UIManager._instance.uiStep == UIManager.UIStep.selectPlayerBuy)
                        {
                            //if (i == 66)
                            //{//选人界面购买界面购买
                            //    mtra.position = startMenu.btn_start.transform.position;
                            //}
                            //else if (i == 67)
                            //{//选人购买界面取消
                            //    mtra.position = gameMenu.btn_Home.transform.position;
                            //} 
                            allBtn[i].onClick.Invoke();
                            return;
                        }


                    }
                }
            }
        } 
    }
    void ClickReturn()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (UIManager._instance.uiStep)
            {
                case UIManager.UIStep.start:
                    ClickBack(startMenu.btn_close);
                    mtra.position = closeMenu.btn_ok.transform.position;
                    break;
                case UIManager.UIStep.close:
                    ClickBack(closeMenu.btn_no);
                    mtra.position = startMenu.btn_start.transform.position;
                    break;
                case UIManager.UIStep.selectPlayer:
                    ClickBack(selectPlayerMenu.btn_Home);
                    mtra.position = startMenu.btn_start.transform.position;
                    break;
                case UIManager.UIStep.selectPlayerBuy:
                    ClickBack(selectPlayerMenu.noBuy);
                    mtra.position = selectPlayerMenu.btn_Play.transform.position;
                    break;
                case UIManager.UIStep.selectLevel:
                    ClickBack(selectLvMenu.btn_Home);
                    mtra.position = startMenu.btn_start.transform.position;
                    break;
                case UIManager.UIStep.game:
                    ClickBack(gameMenu.btn_Home);
                    mtra.position = stopMenu.btn_ok.transform.position;
                    break;
                case UIManager.UIStep.gameStop:
                    ClickBack(stopMenu.btn_ok);
                    mtra.position = gameMenu.btn_Home.transform.position;
                    break;
                case UIManager.UIStep.gameOver:
                    ClickBack(gameOver.btnHome);
                    mtra.position = startMenu.btn_start.transform.position;
                    break;
                default:
                    break;
            }
        }

    }

    void ClickFangxiang()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (UIManager._instance.uiStep)
            {
                case UIManager.UIStep.start:
                    ClickMenuLeft();
                    break;
                case UIManager.UIStep.close:
                    ClickCloseLeft();
                    break;
                case UIManager.UIStep.selectPlayer:
                    ClickSelectPlayerLeft();
                    break;
                case UIManager.UIStep.selectPlayerBuy:
                    ClickSelectPlayerBuyLeft();
                    break;
                case UIManager.UIStep.selectLevel:
                    ClickSelectLvLeft();
                    break;
                case UIManager.UIStep.game: 
                    break;
                case UIManager.UIStep.gameStop:
                    ClickGameStopLeft();
                    break;
                case UIManager.UIStep.gameOver:
                    ClickGameOverLeft();
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (UIManager._instance.uiStep)
            {
                case UIManager.UIStep.start:
                    ClickMenuRight();
                    break;
                case UIManager.UIStep.close:
                    ClickCloseLeft();
                    break;
                case UIManager.UIStep.selectPlayer:
                    ClickSelectPlayerRight();
                    break;
                case UIManager.UIStep.selectPlayerBuy:
                    ClickSelectPlayerBuyLeft();
                    break;
                case UIManager.UIStep.selectLevel:
                    ClickSelectLvRight();
                    break;
                case UIManager.UIStep.game:
                    break;
                case UIManager.UIStep.gameStop:
                    ClickGameStopLeft();
                    break;
                case UIManager.UIStep.gameOver:
                    ClickGameOverRight();
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (UIManager._instance.uiStep)
            {
                case UIManager.UIStep.start:
                    ClickMenuLeft();
                    break;
                case UIManager.UIStep.close:
                    ClickCloseLeft();
                    break;
                case UIManager.UIStep.selectPlayer:
                    ClickSelectPlayerUp();
                    break;
                case UIManager.UIStep.selectPlayerBuy:
                    ClickSelectPlayerBuyLeft();
                    break;
                case UIManager.UIStep.selectLevel:
                    ClickSelectLvUp();
                    break;
                case UIManager.UIStep.game:
                    break;
                case UIManager.UIStep.gameStop:
                    ClickGameStopLeft();
                    break;
                case UIManager.UIStep.gameOver:
                    ClickGameOverLeft();
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (UIManager._instance.uiStep)
            {
                case UIManager.UIStep.start:
                    ClickMenuRight();
                    break;
                case UIManager.UIStep.close:
                    ClickCloseLeft();
                    break;
                case UIManager.UIStep.selectPlayer:
                    ClickSelectPlayerDown();
                    break;
                case UIManager.UIStep.selectPlayerBuy:
                    ClickSelectPlayerBuyLeft();
                    break;
                case UIManager.UIStep.selectLevel:
                    ClickSelectLvDown();
                    break;
                case UIManager.UIStep.game:
                    break;
                case UIManager.UIStep.gameStop:
                    ClickGameStopLeft();
                    break;
                case UIManager.UIStep.gameOver:
                    ClickGameOverRight();
                    break;
                default:
                    break;
            }
        }
    }

    public void ShowInOverWin()
    {
        mtra.position = gameOver.btnPlay.transform.position;
    }
    public void ShowInOverLose()
    {
        mtra.position = gameOver.btnRes.transform.position;
    }
    public void ShowBuy()
    {
         mtra.position = selectLvMenu.levelBtnAll[selectLvMenu.GetLevelData].transform.position; 

    }
    public void ShowInBuyMenu()
    {
        mtra.position = selectPlayerMenu.buy.transform.position;
    }
    public void ShowInBuyMenuClose()
    {
        mtra.position = selectPlayerMenu.btn_Play.transform.position;
    }

    public void ShowInNoCoin()
    { 
        mtra.position = selectPlayerMenu.btn_Play.transform.position;
    }
    public void ShowInCanPlay()
    { 
        mtra.position = gameMenu.btn_Home.transform.position;
    }
    public void ShowInCantPlay(int id)
    { 
        mtra.position = selectLvMenu.levelBtnAll[id].transform.position;
    }
    public void ShowGameToSelectLV()
    {
        mtra.position = selectLvMenu.levelBtnAll[selectLvMenu.GetLevelData].transform.position;
    }

    #region   startmenu方向控制
    void ClickMenuLeft()
    {
        if (mtra.position == startMenu.btn_start.transform.position)
        {
            mtra.position = startMenu.btn_close.transform.position;
        }
        else if (mtra.position == startMenu.btn_close.transform.position)
        {
            mtra.position = startMenu.btn_sound.transform.position;
        }
        else if (mtra.position == startMenu.btn_sound.transform.position)
        {
            mtra.position = startMenu.btn_start.transform.position;
        }
    }
    void ClickMenuRight()
    {
        if (mtra.position == startMenu.btn_start.transform.position)
        {
            mtra.position = startMenu.btn_sound.transform.position;
        }
        else if (mtra.position == startMenu.btn_close.transform.position)
        {
            mtra.position = startMenu.btn_start.transform.position;
        }
        else if (mtra.position == startMenu.btn_sound.transform.position)
        {
            mtra.position = startMenu.btn_close.transform.position;
        }
    }
    #endregion

    #region   clocemenu方向控制
    void ClickCloseLeft()
    {
        if (mtra.position == closeMenu.btn_ok.transform.position)
        {
            mtra.position = closeMenu.btn_no.transform.position;
        }
        else if (mtra.position == closeMenu.btn_no.transform.position)
        {
            mtra.position = closeMenu.btn_ok.transform.position;
        }
    }

    #endregion

    #region   selectPlayermenu方向控制
    void ClickSelectPlayerLeft()
    {
        if (mtra.position == selectPlayerMenu.btn_Home.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_Play.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_20.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_1.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_2.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_1.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_3.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_2.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_4.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_3.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_5.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_4.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_6.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_7.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_6.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_8.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_7.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_9.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_8.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_10.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_9.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_11.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_12.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_11.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_13.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_12.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_14.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_13.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_15.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_14.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_16.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_17.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_16.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_18.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_17.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_19.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_18.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_20.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_19.transform.position;
        }
    }
    void ClickSelectPlayerRight()
    {
        if (mtra.position == selectPlayerMenu.btn_Home.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_1.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_Play.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_1.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_2.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_2.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_3.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_3.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_4.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_4.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_5.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_5.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_6.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_7.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_7.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_8.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_8.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_9.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_9.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_10.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_10.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_11.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_12.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_12.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_13.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_13.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_14.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_14.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_15.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_15.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_16.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_17.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_17.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_18.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_18.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_19.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_19.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_20.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_20.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
    }
    void ClickSelectPlayerUp()
    {
        if (mtra.position == selectPlayerMenu.btn_Home.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_Play.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_20.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_1.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_2.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_3.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_4.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_5.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_6.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_1.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_7.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_2.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_8.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_3.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_9.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_4.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_10.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_5.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_11.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_6.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_12.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_7.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_13.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_8.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_14.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_9.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_15.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_10.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_16.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_11.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_17.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_12.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_18.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_13.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_19.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_14.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_20.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_15.transform.position;
        }
    }
    void ClickSelectPlayerDown()
    {
        if (mtra.position == selectPlayerMenu.btn_Home.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_1.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_Play.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_1.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_6.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_2.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_7.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_3.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_8.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_4.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_9.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_5.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_10.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_6.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_11.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_7.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_12.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_8.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_13.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_9.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_14.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_10.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_15.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_11.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_16.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_12.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_17.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_13.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_18.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_14.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_19.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_15.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_20.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_16.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_17.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_18.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_19.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.btn_20.transform.position)
        {
            mtra.position = selectPlayerMenu.btn_Play.transform.position;
        }
    }

    #endregion

    #region   selectLVmenu方向控制
    void ClickSelectLvLeft()
    {
        if (isHaveClick == true) return;
            if (mtra.position == selectLvMenu.btn_Home.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0 || selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.btn_Right.transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.levelBtnAll[29].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Left.transform.position)
        {
            if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.btn_Right.transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.levelBtnAll[29].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Right.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.levelBtnAll[4].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.levelBtnAll[14].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[0].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[1].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[0].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[2].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[1].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[3].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[2].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[4].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[3].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[5].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[6].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[5].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[7].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[6].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[8].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[7].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[9].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[8].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[10].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[11].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[10].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[12].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[11].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[13].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[12].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[14].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[13].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[15].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[16].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[15].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[17].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[16].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[18].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[17].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[19].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[18].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[20].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[21].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[20].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[22].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[21].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[23].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[22].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[24].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[23].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[25].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[26].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[25].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[27].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[26].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[28].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[27].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[29].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[28].transform.position;
        }
    }
    void ClickSelectLvRight()
    {
        if (isHaveClick == true) return;
        if (mtra.position == selectLvMenu.btn_Home.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.levelBtnAll[0].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.btn_Left.transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.btn_Left.transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Left.transform.position)
        {
            if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.levelBtnAll[10].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.levelBtnAll[20].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Right.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.btn_Home.transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.btn_Home.transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[0].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[1].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[1].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[2].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[2].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[3].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[3].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[4].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[4].transform.position)
        {
            mtra.position = selectLvMenu.btn_Right.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[5].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[6].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[6].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[7].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[7].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[8].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[8].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[9].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[9].transform.position)
        {
            mtra.position = selectLvMenu.btn_Right.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[10].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[11].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[11].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[12].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[12].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[13].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[13].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[14].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[14].transform.position)
        {
            mtra.position = selectLvMenu.btn_Right.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[15].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[16].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[16].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[17].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[17].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[18].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[18].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[19].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[19].transform.position)
        {
            mtra.position = selectLvMenu.btn_Right.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[20].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[21].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[21].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[22].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[22].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[23].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[23].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[24].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[24].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[25].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[26].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[26].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[27].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[27].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[28].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[28].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[29].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[29].transform.position)
        {
            mtra.position = selectLvMenu.btn_Left.transform.position;
        }
    }
    void ClickSelectLvUp()
    {
        if (isHaveClick == true) return;
        if (mtra.position == selectLvMenu.btn_Home.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.levelBtnAll[5].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.levelBtnAll[15].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.levelBtnAll[25].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Left.transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.btn_Right.transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[0].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[1].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[2].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[3].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[4].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[5].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[0].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[6].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[1].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[7].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[2].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[8].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[3].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[9].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[4].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[10].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[11].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[12].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[13].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[14].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[15].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[10].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[16].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[11].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[17].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[12].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[18].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[13].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[19].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[14].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[20].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[21].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[22].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[23].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[24].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[25].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[20].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[26].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[21].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[27].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[22].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[28].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[23].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[29].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[24].transform.position;
        }
    }
    void ClickSelectLvDown()
    {
        if (isHaveClick == true) return;
        if (mtra.position == selectLvMenu.btn_Home.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.levelBtnAll[0].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.btn_Left.transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.btn_Left.transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Left.transform.position)
        {
            if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.levelBtnAll[15].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 2)
            {
                mtra.position = selectLvMenu.levelBtnAll[25].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.btn_Right.transform.position)
        {
            if (selectLvMenu.GetMenuID == 0)
            {
                mtra.position = selectLvMenu.levelBtnAll[9].transform.position;
            }
            else if (selectLvMenu.GetMenuID == 1)
            {
                mtra.position = selectLvMenu.levelBtnAll[19].transform.position;
            }
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[0].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[5].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[1].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[6].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[2].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[7].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[3].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[8].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[4].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[9].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[5].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[6].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[7].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[8].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[9].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[10].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[15].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[11].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[16].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[12].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[17].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[13].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[18].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[14].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[19].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[15].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[16].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[17].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[18].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[19].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[20].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[25].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[21].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[26].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[22].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[27].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[23].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[28].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[24].transform.position)
        {
            mtra.position = selectLvMenu.levelBtnAll[29].transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[25].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[26].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[27].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[28].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
        else if (mtra.position == selectLvMenu.levelBtnAll[29].transform.position)
        {
            mtra.position = selectLvMenu.btn_Home.transform.position;
        }
    }
    #endregion

    #region   gamemenu方向控制
    void ClickGameLeft()
    {
       // print("+++++++++++++");
    }
    #endregion

    #region   gameStopmenu方向控制
    void ClickGameStopLeft()
    {
        if (mtra.position == stopMenu.btn_ok.transform.position)
        {
            mtra.position = stopMenu.btn_no.transform.position;
        }
        else if (mtra.position == stopMenu.btn_no.transform.position)
        {
            mtra.position = stopMenu.btn_ok.transform.position;
        }
    }
    #endregion

    #region   gameOvermenu方向控制
    void ClickGameOverLeft()
    {
        if (mtra.position == gameOver.btnRes.transform.position)
        {
            mtra.position = gameOver.btnHome.transform.position;
        }
        else if (mtra.position == gameOver.btnHome.transform.position)
        {
            mtra.position = gameOver.btnPlay.transform.position;
        }
        else if (mtra.position == gameOver.btnPlay.transform.position)
        {
            mtra.position = gameOver.btnRes.transform.position;
        }
    }
    void ClickGameOverRight()
    {
        if (mtra.position == gameOver.btnRes.transform.position)
        {
            mtra.position = gameOver.btnPlay.transform.position;
        }
        else if (mtra.position == gameOver.btnHome.transform.position)
        {
            mtra.position = gameOver.btnRes.transform.position;
        }
        else if (mtra.position == gameOver.btnPlay.transform.position)
        {
            mtra.position = gameOver.btnHome.transform.position;
        }
    }
    #endregion

    #region
    void ClickSelectPlayerBuyLeft()
    {
        if (mtra.position == selectPlayerMenu.buy.transform.position)
        {
            mtra.position = selectPlayerMenu.noBuy.transform.position;
        }
        else if (mtra.position == selectPlayerMenu.noBuy.transform.position)
        {
            mtra.position = selectPlayerMenu.buy.transform.position;
        }
    }
    #endregion
}
