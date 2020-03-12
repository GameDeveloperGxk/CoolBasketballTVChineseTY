using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    private Transform mTra;
    public float speed = 80f;
    private float moveX = 0;
    public Transform point_touqiu;

    float time = 0;
    float use = 1f;//多长时间抢断一次
    void Qiang()
    { 
        time += Time.deltaTime;
        if (time >= use)
        {
            time = 0;
            int a = Random.Range(0,100);
            if (a < 50)
            { 
                GameController._instance.whoHaveBall = GameController.WhoHaveBall.npc;
            }
        }
    }

    void FixedUpdate()
    {

        if (GameController._instance.isstart == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }

        if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            moveX = 1;
        }
        else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
        {
            if (transform.position.x < GameController._instance.player.transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);

            
                if (transform.position.x >= GameController._instance.player.transform.position.x + 80)
                {
                    moveX = 1;
                }
                else if (transform.position.x <= GameController._instance.player.transform.position.x + 75)
                {
                    moveX = -1;
                }
                else
                {
                    moveX = 0;
                }
            if (GameController._instance.isCanQiangDuan)
            {
                Qiang();
            }
            else
            {
                time = 0;
            }
            
                 
        }
        else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
        {
            if (GameController._instance.tagetBall.x < transform.position.x - 60)
            {
                moveX = 1;
                transform.localScale = new Vector3(-1, 1, 1);
                if (GameController._instance.tagetBall.y > transform.position.y && Vector3.Distance(GameController._instance.tagetBall, transform.position) <= 200)
                {
                    if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
                    {
                        transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[4]);
                    }
                }

            }
            else if (GameController._instance.tagetBall.x > transform.position.x + 60)
            {
                moveX = -1;
                transform.localScale = new Vector3(1, 1, 1);
                if (GameController._instance.tagetBall.y > transform.position.y && Vector3.Distance(GameController._instance.tagetBall, transform.position) <= 200)
                {
                    if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
                    {
                        transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[4]);
                    }
                }
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                moveX = 0;
            }

        }
        GetComponent<Rigidbody2D>().velocity = (Vector2.left * moveX) * (speed + GameController._instance.playerValue[GameController._instance.NowUsePlayerID, 0] * 2);

        AnimatorStateInfo info = transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime > 1.0f)
        {
            if (info.IsName(GameController._instance.animName[4]))
            {
                if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[6]);
                }
                else
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);
                }
            }
            else if (info.IsName(GameController._instance.animName[5]))
            {
                if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
                else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
                else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
            }
            else if (info.IsName(GameController._instance.animName[6]))
            {
                transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
            }
            else if (info.IsName(GameController._instance.animName[7]))
            {
                transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);
                int a = UnityEngine.Random.Range(0, 100);
                bool isIn = false;
                if (a > 95)
                {
                    isIn = false;
                }
                else
                {
                    isIn = true;
                }
                GameController._instance.isShootInNPC = isIn;
                GameController._instance.leftLankuang.Play(isIn);
            }
            else if (info.IsName(GameController._instance.animName[8]))
            {
                transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);

                GameController._instance.flyBallF.SetActive(true);
                GameController._instance.flyBall.Move(point_touqiu.gameObject, GameController._instance.leftPoint_UP.gameObject);


            }
            else if (info.IsName(GameController._instance.animName[9]))
            {
                transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);
                int a = UnityEngine.Random.Range(0, 100);
                bool isIn = false;
                if (a > 95)
                {
                    isIn = false;
                }
                else
                {
                    isIn = true;
                }
                GameController._instance.isShootInNPC = isIn;
                GameController._instance.leftLankuang.Play(isIn);
            }
        }
        if (moveX == 0)
        {//不移动

            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {//谁都没球时，待机动画 
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[2]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[3]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false
            // && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
            {//玩家有球时，如果没在播投球动画
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
            {
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[2]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[2]);
                }
            }
        }
        if (moveX != 0)
        {//移动 
            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[10]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
            {
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[11]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
            {
                if (transform.position.x < GameController._instance.player.transform.position.x)
                {
                    if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false )
                    {
                        transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[10]);
                    }
                }
                else
                {
                    if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[3]) == false
                     && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                     && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                     && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                    {
                        transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[3]);
                    }
                }
            }
        }
        if (transform.localPosition.x >= 5)
        {
            transform.localPosition = new Vector3(5, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x <= -5)
        {
            transform.localPosition = new Vector3(-5f, transform.localPosition.y, transform.localPosition.z);
        }
    }
    //   > 1.68三分    <=1.75 >=-4.1 投球2分   <-4.1上篮或者灌篮

         
     void Tiao()
    {
         if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
        {
             
            if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
            && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
            {
                if (transform.localPosition.x >1.68f)
                {
                    GameController._instance.isSanFenNPC = true;
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[8]);
                }
                else if (transform.localPosition.x <= 1.68f && transform.localPosition.x >= -4.1f)
                {
                    GameController._instance.isSanFenNPC = false;
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[8]);
                }
                else if (transform.localPosition.x < -4.1f)
                {
                    GameController._instance.isSanFenNPC = false;
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(Random.Range(0, 100) > 50 ? GameController._instance.animName[7] : GameController._instance.animName[9]);
                }
                GameController._instance.whoHaveBall = GameController.WhoHaveBall.none;
            }
        } 
    }


    public void StopPlay(bool isStop)
    { 
        if (isStop)
            transform.Find("npcFather/Armature").GetComponent<Animator>().speed = 0;
        else
            transform.Find("npcFather/Armature").GetComponent<Animator>().speed = 2;

    }


    public void ResAnimator()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        transform.Find("npcFather/Armature").GetComponent<Animator>().speed = 2;
        transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {
                GameController._instance.whoHaveBall = GameController.WhoHaveBall.npc;
                GameController._instance.ballF.SetActive(false);
                if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[0]) == true
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
                else if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == true
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[6]);
                }
                else if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == true
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
                else if (transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == true
                    && transform.Find("npcFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false)
                {
                    transform.Find("npcFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[11]);
                }
            }
        }

        if (collision.gameObject.CompareTag("shoot"))
        {
            if (collision.gameObject.name == "2")
            { 
                if (Random.Range(0, 100) >=99 )
                {
                    Tiao();
                }
            }
            else if (collision.gameObject.name == "5")
            { 
                if (Random.Range(0, 100) < 2)
                {
                    Tiao();
                }
            }
            else if (collision.gameObject.name == "30")
            { 
                if (Random.Range(0, 100) < 30)
                {
                    Tiao();
                }
            }
            else if (collision.gameObject.name == "40")
            { 
                if (Random.Range(0, 100) < 40)
                {
                    Tiao();
                }
            }
            else if (collision.gameObject.name == "100")
            { 
                if (Random.Range(0, 100) < 100)
                {
                    Tiao();
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("shoot"))
        {
            if (collision.gameObject.name == "100")
                Tiao();
        }
    }

}
