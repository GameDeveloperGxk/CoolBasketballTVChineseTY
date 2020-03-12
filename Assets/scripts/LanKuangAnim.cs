using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanKuangAnim : MonoBehaviour {


    private GameObject root;

    public Transform point_dowm_in;
    public Transform point_down_out;

    bool jiance = false;
    private void Awake()
    {
        root = transform.Find("root").gameObject;
    }

    void Start ()
    {
		
	}
	 
	void Update ()
    {
        if (jiance == false) return;
        AnimatorStateInfo info =  GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime > 1.0f)
        {
            if (info.IsName("jinkuang"))
            {
                GameController._instance.downBall.transform.position = point_dowm_in.position;
                GameController._instance.downBall.SetActive(true);
                root.SetActive(false );
                if (gameObject.name == "Armature_right")
                { 
                    if (GameController._instance.isSanFenPlayer == true)
                    { 
                        GameController._instance.isSanFenPlayer = false;
                        grade.redgrade += 3;
                    }
                    else
                    { 
                        grade.redgrade += 2;
                    }
                }
                else if (gameObject.name == "Armature_left")
                {
                    if (GameController._instance.isSanFenNPC == true)
                    {
                        GameController._instance.isSanFenNPC = false;
                        text .bluegrade += 3;
                    }
                    else
                    {
                        text.bluegrade += 2;
                    }
                }
                GameController._instance.isstart = false;
                GameController._instance.ResetPos();
            }
            else if (info.IsName("meijin"))
            { 
                GameController._instance.downBall.transform.position = point_down_out.position;
                GameController._instance.downBall.SetActive(true);
                root.SetActive(false );

                GameController._instance.isSanFenPlayer = false;

            }
            jiance = false;
        }
    }
    public void StopPlay(bool isStop)
    {
        if (isStop)
            GetComponent<Animator>().speed = 0;
        else
            GetComponent<Animator>().speed = 2;

    }

    public void InIt()
    {
        GetComponent<Animator>().speed = 2;
        GetComponent<Animator>().Play("none");
    }


    public void Play(bool isJin)
    {
        GetComponent<Animator>().Rebind();
        root.SetActive(true);
        if (isJin == true)
        {//播放进球动画
            GetComponent<Animator>().Play("jinkuang");
        }
        else
        {//播放弹出动画
            GetComponent<Animator>().Play("meijin");
        }
        jiance = true;
    }
}
