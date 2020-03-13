using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource audioSourceBG;
    public AudioSource audioSourceOne;
    public AudioClip[] audioClipsBG;
    public AudioClip[] audioClipsOne;
    int playID = 0;
    Action action;

    public void FristPlayBG(int id)
    { 
        audioSourceBG.clip = audioClipsBG[id]; 
        audioSourceBG.Play();
    }

    /// <summary>
    /// 0.ui
    /// 1.game1 
    /// </summary>
    /// <param name="id"></param>
    public void PlayBG(int id )
    { 
        if (GameController._instance.SoundOpen == false) return;
        audioSourceBG.clip = audioClipsBG[id];
       
        audioSourceBG.Play();
    }
    /// <summary>
    /// 0.哨声
    /// 1.球落地
    /// 2.胜利
    /// 3.失败
    /// 4.进球欢呼
    /// 5.倒计时声音
    /// 6.按钮点击声
    /// 7.失球欢呼
    /// 8.投篮
    /// 9.投三分
    /// 10.扣篮
    /// </summary>
    /// <param name="id"></param>
    public void PlayOne(int id)
    { 
        if (GameController._instance.SoundOpen == false) return;
        audioSourceOne.PlayOneShot(audioClipsOne[id]);
    }

    private void Update()
    {
        if (GameController._instance.SoundOpen == false)
        {
            if(audioSourceBG.enabled == true)
                audioSourceBG.enabled = false;
            if (audioSourceOne.enabled == true)
                audioSourceOne.enabled = false;
        }
        else
        {
            if (audioSourceBG.enabled == false)
                audioSourceBG.enabled = true;
            if (audioSourceOne.enabled == false)
                audioSourceOne.enabled = true;
        }
    }
}
