using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseMenu : MonoBehaviour {

    //public Button btn_close;
    public Button btn_ok;
    public Button btn_no;


    void Start()
    {
        //btn_close.onClick.AddListener(CloseClick);
        btn_ok.onClick.AddListener(OkClick);
        btn_no.onClick.AddListener(NoClick);

    }

    void Update()
    {

    }

    void CloseClick()
    {
        if (UIManager._instance.uiStep == UIManager.UIStep.close)
        {
            UIManager._instance.audioManager.PlayOne(6);
            UIManager._instance.ShowOrHideClose(false);
            UIManager._instance.uiStep = UIManager.UIStep.start;
        }
    }
    void OkClick()
    {
        if (UIManager._instance.uiStep == UIManager.UIStep.close)
        {
            UIManager._instance.audioManager.PlayOne(6);
            Application.Quit();
        }
    }
    void NoClick()
    {
        if (UIManager._instance.uiStep == UIManager.UIStep.close)
        {
            UIManager._instance.audioManager.PlayOne(6);
            UIManager._instance.ShowOrHideClose(false);
            UIManager._instance.uiStep = UIManager.UIStep.start;
        }
    }
}
