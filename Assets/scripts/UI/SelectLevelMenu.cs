using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLevelMenu : MonoBehaviour {

    public Button btn_Home;
    public Button btn_Left;
    public Button btn_Right;
    public Text coinLabel; 
    public GameObject tishi;
    public Button[] levelBtnAll;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject panel3;
    private int starX1 = 0;
    private int starX2 = 2300/2;
    private int starX3 = 4600/2;
    private float tishiShowTime = 1f;

    public Transform hui1;
    public Transform hui2;
    public Transform hui3;
    public Transform huang;

    private void OnEnable()
    {
        if (PlayerPrefs.GetInt(levelDataName) < 10)
        {
            menuID = 0;
            panel1.transform.localPosition = new Vector2(starX1 ,0);
            panel2.transform.localPosition = new Vector2(starX2, 0);
            panel3.transform.localPosition = new Vector2(starX3, 0);
        }
        else if (PlayerPrefs.GetInt(levelDataName) < 20)
        {
            menuID = 1;
            panel1.transform.localPosition = new Vector2(-starX2, 0);
            panel2.transform.localPosition = new Vector2(starX1, 0);
            panel3.transform.localPosition = new Vector2(starX2, 0);
        }
        else
        {
            menuID = 2;
            panel1.transform.localPosition = new Vector2(-starX3, 0);
            panel2.transform.localPosition = new Vector2(-starX2, 0);
            panel3.transform.localPosition = new Vector2(starX1, 0);
        }

        LevelData();

        tishi.transform.localScale = new Vector3(0, 0, 0);
    }

    void Start()
    {
        btn_Home.onClick.AddListener(HomeClick);
        btn_Left.onClick.AddListener(LeftClick);
        btn_Right.onClick.AddListener(RightClick);
        levelBtnAll[0].onClick.AddListener(LevelClick1);
        levelBtnAll[1].onClick.AddListener(LevelClick2);
        levelBtnAll[2].onClick.AddListener(LevelClick3);
        levelBtnAll[3].onClick.AddListener(LevelClick4);
        levelBtnAll[4].onClick.AddListener(LevelClick5);
        levelBtnAll[5].onClick.AddListener(LevelClick6);
        levelBtnAll[6].onClick.AddListener(LevelClick7);
        levelBtnAll[7].onClick.AddListener(LevelClick8);
        levelBtnAll[8].onClick.AddListener(LevelClick9);
        levelBtnAll[9].onClick.AddListener(LevelClick10);
        levelBtnAll[10].onClick.AddListener(LevelClick11);
        levelBtnAll[11].onClick.AddListener(LevelClick12);
        levelBtnAll[12].onClick.AddListener(LevelClick13);
        levelBtnAll[13].onClick.AddListener(LevelClick14);
        levelBtnAll[14].onClick.AddListener(LevelClick15);
        levelBtnAll[15].onClick.AddListener(LevelClick16);
        levelBtnAll[16].onClick.AddListener(LevelClick17);
        levelBtnAll[17].onClick.AddListener(LevelClick18);
        levelBtnAll[18].onClick.AddListener(LevelClick19);
        levelBtnAll[19].onClick.AddListener(LevelClick20);
        levelBtnAll[20].onClick.AddListener(LevelClick21);
        levelBtnAll[21].onClick.AddListener(LevelClick22);
        levelBtnAll[22].onClick.AddListener(LevelClick23);
        levelBtnAll[23].onClick.AddListener(LevelClick24);
        levelBtnAll[24].onClick.AddListener(LevelClick25);
        levelBtnAll[25].onClick.AddListener(LevelClick26);
        levelBtnAll[26].onClick.AddListener(LevelClick27);
        levelBtnAll[27].onClick.AddListener(LevelClick28);
        levelBtnAll[28].onClick.AddListener(LevelClick29);
        levelBtnAll[29].onClick.AddListener(LevelClick30);
         
    }

    private void Update()
    {
        ChangeShowLeftRight();
        if (coinLabel.text != UIManager._instance.CoinNum.ToString())
        {
            coinLabel.text = UIManager._instance.CoinNum.ToString();
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            GetLevelData += 6;
        }

        if (menuID == 0)
        {
            if (huang.position != hui1.position)
            {
                huang.position = hui1.position;
            }
        }
        else if (menuID == 1 )
        {
            if (huang.position != hui2.position)
            {
                huang.position = hui2.position;
            }
        }
        else if (menuID == 2)
        {
            if (huang.position != hui3.position)
            {
                huang.position = hui3.position;
            }
        }
    }

    string levelDataName = "LevelDataNum";
    void LevelData()
    {
        if (PlayerPrefs.HasKey(levelDataName) == false)
        {
            PlayerPrefs.SetInt(levelDataName, 0);
        }

        for (int i = 0; i < PlayerPrefs.GetInt(levelDataName) + 1; i++)
        {
            levelBtnAll[i].transform.Find("Image1").gameObject.SetActive(true);
            levelBtnAll[i].transform.Find("Image2").gameObject.SetActive(true);
        }
    }

    public int GetLevelData
    {
        get{ return PlayerPrefs.GetInt(levelDataName); }
        set { PlayerPrefs.SetInt(levelDataName, value); }
    }

    IEnumerator ShowTishi()
    { 
        LeanTween.scale(tishi,new Vector3(1,1,1),0.5f);
        yield return new WaitForSeconds(tishiShowTime);
        LeanTween.scale(tishi, new Vector3(0, 0, 0), 0.5f); 
    }


    void LevelClick(int lv)
    {
        if (lv <= PlayerPrefs.GetInt(levelDataName))
        {//可以进入
            GameController._instance.NowPlayLevel = lv;
            UIManager._instance.audioManager.PlayOne(6);
            UIManager._instance.ShowOrHideSelectLevel(false);
            GameController._instance.ShowOrHideGame(true);
            UIManager._instance.ShowOrHideGame(true);
            UIManager._instance.uiStep = UIManager.UIStep.game;
            GameController._instance.ResetPos();

            //更换背景音乐
            UIManager._instance.audioManager.PlayBG(Random.Range(2, 4));
            if (GameController._instance.IsUseHand == true)
                GameController._instance.hand.GetComponent<UISelect>().ShowInCanPlay();

        }
        else
        {//不可进入
            StartCoroutine(ShowTishi());
            if (GameController._instance.IsUseHand == true)
                GameController._instance.hand.GetComponent<UISelect>().ShowInCantPlay(lv);
        }
    }
    void ChangeShowLeftRight()
    {
        if (menuID == 0)
        {
            if (btn_Left.gameObject.activeSelf == true)
            {
                btn_Left.gameObject.SetActive(false);
            }
            if (btn_Right.gameObject.activeSelf == false )
            {
                btn_Right.gameObject.SetActive(true);
            }
        }
        else if (menuID == 1)
        {
            if (btn_Left.gameObject.activeSelf == false)
            {
                btn_Left.gameObject.SetActive(true);
            }
            if (btn_Right.gameObject.activeSelf == false)
            {
                btn_Right.gameObject.SetActive(true);
            }
        }
        else if (menuID == 2)
        {
            if (btn_Left.gameObject.activeSelf == false)
            {
                btn_Left.gameObject.SetActive(true);
            }
            if (btn_Right.gameObject.activeSelf == true)
            {
                btn_Right.gameObject.SetActive(false );
            }
        }

    }

    void HomeClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        UIManager._instance.ShowOrHideSelectLevel(false);
        UIManager._instance.ShowOrHideStart(true);
        UIManager._instance.uiStep = UIManager.UIStep.start;
    }

    //当前显示界面编号 0，1，2
    int menuID = 0;
    float tweenTime = 0.5f;
    public int GetMenuID { get { return menuID; } }
    void LeftClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        if (menuID == 1)
        {
            menuID = 0;
            LeanTween.moveLocalX(panel1, starX1, tweenTime);
            LeanTween.moveLocalX(panel2, starX2, tweenTime);
            LeanTween.moveLocalX(panel3, starX3, tweenTime);
        }
        else if (menuID == 2)
        {
            menuID = 1;
            LeanTween.moveLocalX(panel1, -starX2, tweenTime);
            LeanTween.moveLocalX(panel2, starX1, tweenTime);
            LeanTween.moveLocalX(panel3, starX2, tweenTime);
        }
    }
    void RightClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        if (menuID == 0)
        {
            menuID = 1;
            LeanTween.moveLocalX(panel1,-starX2, tweenTime);
            LeanTween.moveLocalX(panel2, starX1, tweenTime);
            LeanTween.moveLocalX(panel3, starX2, tweenTime);
        }
        else if (menuID == 1)
        {
            menuID = 2;
            LeanTween.moveLocalX(panel1, -starX3, tweenTime);
            LeanTween.moveLocalX(panel2, -starX2, tweenTime);
            LeanTween.moveLocalX(panel3, starX1, tweenTime);
        }
    }

    #region  管卡按钮点击
    void LevelClick1()
    {
        LevelClick(0);
    }
    void LevelClick2()
    {
        LevelClick(1);
    }
    void LevelClick3()
    {
        LevelClick(2);
    }
    void LevelClick4()
    {
        LevelClick(3); 
    }
    void LevelClick5()
    {
        LevelClick(4);
    }
    void LevelClick6()
    {
        LevelClick(5);
    }
    void LevelClick7()
    {
        LevelClick(6);
    }
    void LevelClick8()
    {
        LevelClick(7);
    }
    void LevelClick9()
    {
        LevelClick(8); 
    }
    void LevelClick10()
    {
        LevelClick(9);
    }
    void LevelClick11()
    {
        LevelClick(10);
    }
    void LevelClick12()
    {
        LevelClick(11);
    }
    void LevelClick13()
    {
        LevelClick(12);
    }
    void LevelClick14()
    {
        LevelClick(13);
    }
    void LevelClick15()
    {
        LevelClick(14);
    }
    void LevelClick16()
    {
        LevelClick(15);
    }
    void LevelClick17()
    {
        LevelClick(16);
    }
    void LevelClick18()
    {
        LevelClick(17);
    }
    void LevelClick19()
    {
        LevelClick(18);
    }
    void LevelClick20()
    {
        LevelClick(19);
    }
    void LevelClick21()
    {
        LevelClick(20);
    }
    void LevelClick22()
    {
        LevelClick(21);
    }
    void LevelClick23()
    {
        LevelClick(22);
    }
    void LevelClick24()
    {
        LevelClick(23);
    }
    void LevelClick25()
    {
        LevelClick(24);
    }
    void LevelClick26()
    {
        LevelClick(25);
    }
    void LevelClick27()
    {
        LevelClick(26);
    }
    void LevelClick28()
    {
        LevelClick(27);
    }
    void LevelClick29()
    {
        LevelClick(28);
    }
    void LevelClick30()
    {
        LevelClick(29);
    }
    #endregion
}
