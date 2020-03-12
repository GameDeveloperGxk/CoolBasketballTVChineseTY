using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySprite : MonoBehaviour {

    public Image spriteRenderer;

    public float playRate = 5;
    private float rate;
    private float timer = 0;
    public Sprite[] spriteArray;
    public int nowFrame = 0;

    public bool isLoop = false;
    public PlaySprite playSprite;

    private void OnEnable()
    {
        rate = 1 / playRate;
        nowFrame = 0;
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = spriteArray[nowFrame];
    }

    void Start()
    {
       

    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer >= rate)
        {
            timer -= rate;
            nowFrame++;
            if (isLoop)
            {
                nowFrame %= spriteArray.Length;
            }
            else
            {
                nowFrame = spriteArray.Length - 1;
            }
            if (nowFrame >= spriteArray.Length-1)
            {
                spriteRenderer.sprite = spriteArray[0];
                playSprite.enabled = false;
                spriteRenderer.enabled = false;
            }
            else
            {
                spriteRenderer.sprite = spriteArray[nowFrame];
            }
        }

    }
}
