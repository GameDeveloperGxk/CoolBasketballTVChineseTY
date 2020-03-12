using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {


    public Button btn_close;
    public Button btn_start;
    public Button btn_sound;
    public Image soundImage;
    public Sprite[] spriteSound;


    private void OnEnable()
    {
 
    }

    void Start () {
        btn_close.onClick.AddListener(CloseClick);
        btn_start.onClick.AddListener(StartClick);
        btn_sound.onClick.AddListener(SoundClick);
        GameController._instance.SoundOpen = true;
        soundImage.sprite = spriteSound[1];
    }
	 
	void Update ()
    {
		
	}

    void CloseClick()
    {
        if (UIManager._instance.uiStep == UIManager.UIStep.start)
        {
            UIManager._instance.audioManager.PlayOne(6);
            UIManager._instance.ShowOrHideClose(true);
            UIManager._instance.uiStep = UIManager.UIStep.close;
        }
    }
    void StartClick()
    {
        if (UIManager._instance.uiStep == UIManager.UIStep.start)
        {
            UIManager._instance.audioManager.PlayOne(6);
            UIManager._instance.ShowOrHideSelectPlayer(true);
            UIManager._instance.ShowOrHideStart(false);
            UIManager._instance.uiStep = UIManager.UIStep.selectPlayer;
            GameController._instance.NowUsePlayerID = 0;
        }
    }
    void SoundClick()
    {
        UIManager._instance.audioManager.PlayOne(6);
        if (UIManager._instance.uiStep == UIManager.UIStep.start)
        {
            if (GameController._instance.SoundOpen == false)
            {
                GameController._instance.SoundOpen = true;
                soundImage.sprite = spriteSound[1]; 
            }
            else
            {
                GameController._instance.SoundOpen = false;
                soundImage.sprite = spriteSound[0];
            }
        }
    }
}
