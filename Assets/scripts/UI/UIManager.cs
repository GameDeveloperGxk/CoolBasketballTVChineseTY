using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public static UIManager _instance;
    public enum UIStep
    {
        start,close,selectPlayer,selectPlayerBuy,selectLevel,game,gameStop,gameOver
    }
    public UIStep uiStep = UIStep.start;

    public GameObject startMenu;
    public GameObject selectPlayerMenu;
    public GameObject selectLevelMenu;
    public GameObject gameMenu;
    public GameOver gameOver;
    public AudioManager audioManager;

    public Sprite [] allName;
    public PlaySprite playSprite;
    private void Awake()
    {
        _instance = this;

        audioManager.FristPlayBG(Random.Range(0, 2));
    }

    // Use this for initialization
    void Start ()
    {
        uiStep = UIStep.start;
        
        CoinData();
         
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
	}

    

   public void ShowOrHideClose(bool isShow)
    {
        if (isShow)
            startMenu.transform.Find("PanelClose").gameObject.SetActive(true);
        else
            startMenu.transform.Find("PanelClose").gameObject.SetActive(false);
    }
    public void ShowOrHideStart(bool isShow)
    {
        if (isShow)
            startMenu.SetActive(true);
        else
            startMenu.SetActive(false);
    }
    public void ShowOrHideSelectPlayer(bool isShow)
    {
        if (isShow)
            selectPlayerMenu.SetActive(true);
        else
            selectPlayerMenu.SetActive(false);
    }
    public void ShowOrHideSelectLevel(bool isShow)
    {
        if (isShow)
            selectLevelMenu.SetActive(true);
        else
            selectLevelMenu.SetActive(false);
    }
    public void ShowOrHideGame(bool isShow)
    {
        if (isShow)
        {
            gameMenu.SetActive(true);
            GameController._instance.ShowOrHideGame(true);
        }
        else
            gameMenu.SetActive(false);
    }
    public void ShowOrHideGameStop(bool isShow)
    {
        if (isShow)
            gameMenu.transform.Find("PanelStop").gameObject.SetActive(true);
        else
            gameMenu.transform.Find("PanelStop").gameObject.SetActive(false);
    }
    
public void ShowOrHideGameOver(bool isShow)
    {
        if (isShow)
            gameMenu.transform.Find("PanelOver").gameObject.SetActive(true);
        else
            gameMenu.transform.Find("PanelOver").gameObject.SetActive(false);
    }


    string coinData = "coinData";
    void CoinData()
    {
        if (PlayerPrefs.HasKey(coinData) == false)
        {
            PlayerPrefs.SetInt(coinData, 5000);
        } 
    }
    public int CoinNum
    {
        get { return PlayerPrefs.GetInt(coinData); }

        set { PlayerPrefs.SetInt(coinData, value); }
    }

    public int LevelData
    {
        get { return selectLevelMenu.GetComponent<SelectLevelMenu>().GetLevelData; }
        set { selectLevelMenu.GetComponent<SelectLevelMenu>().GetLevelData = value; }
    }
}
