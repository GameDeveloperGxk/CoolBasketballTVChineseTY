using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player : MonoBehaviour {

    void OnEnable()
    {
      
    } 
    void Start () {
       // GameController._instance.isstart = true;
      //  GameController._instance.whoHaveBall = GameController.WhoHaveBall.npc;
    }

    public float speed = 50f; 
    private float moveX = 0;
    public Transform point_touqiu;
    public Transform point_touqiushanglan;
    public Transform point_touqiuguanlan;

    public float MoveX { get { return moveX; } set { moveX = value; } }

    void FixedUpdate()
    { //得到用户输入，用输入轴实现平滑输入 
         
        if (GameController._instance.isstart == false)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            return;
        }
         
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = 1;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveX = 0;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX = -1;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveX = 0;
        }
        if (Input.anyKey == false)
        {
            moveX = 0; 
        }
        GetComponent<Rigidbody2D>().velocity = ( Vector2.left * moveX) * (speed + GameController._instance.playerAllValue[GameController._instance.NowUsePlayerID, 2] /100 * 8);

        AnimatorStateInfo info = transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);
        if (info.normalizedTime > 0.5f)
        {
            if (info.IsName(GameController._instance.animName[9]))
            {
                UIManager._instance.audioManager.PlayOne(8);
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                GameController._instance.flyBallF.SetActive(true);
                GameController._instance.flyBall.Move(point_touqiuguanlan.gameObject, GameController._instance.leftPoint_UP.gameObject);
                //int a = UnityEngine.Random.Range(0, 100);
                //bool isIn = false;
                //if (a > 65)
                //{
                //    isIn = false;
                //}
                //else
                //{
                //    isIn = true;
                //}
                //GameController._instance.isShootInPlayer = isIn;
                //GameController._instance.rightLankuang.Play(isIn);
            }
        }
        if (info.normalizedTime > 1.0f)   
        {
            if (info.IsName(GameController._instance.animName[4]))
            {
                if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[6]);
                }
                else
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);
                }
            }
            else if (info.IsName(GameController._instance.animName[5]))
            {
                if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
                else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[2]);
                }
                else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
            }
            else if (info.IsName(GameController._instance.animName[6]))
            { 
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
            }
            else if (info.IsName(GameController._instance.animName[7]))
            {
                UIManager._instance.audioManager.PlayOne(8);
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);
                GameController._instance.flyBallF.SetActive(true);
                GameController._instance.flyBall.Move(point_touqiushanglan.gameObject, GameController._instance.leftPoint_UP.gameObject);
                //int a = UnityEngine.Random.Range(0, 100);
                //bool isIn = false;
                //if (a > 65)
                //{
                //    isIn = false;
                //}
                //else
                //{
                //    isIn = true;
                //}
                //GameController._instance.isShootInPlayer = isIn;
                //GameController._instance.rightLankuang.Play(isIn);
            }
            else if (info.IsName(GameController._instance.animName[8]))
            {
                UIManager._instance.audioManager.PlayOne(9);
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[5]);

                GameController._instance.flyBallF.SetActive(true);
                GameController._instance.flyBall.Move(point_touqiu.gameObject, GameController._instance.rightPoint_UP.gameObject);


            }
             
        }
        if (moveX == 0  )
        {//不移动
            
            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {//谁都没球时，待机动画 
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[2]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[3]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false
           // && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
            {//玩家有球时，如果没在播投球动画
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false 
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false )
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
            {
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[2]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[2]);
                }
            }
        }
        if (moveX != 0  )
        {//移动 
            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[10]);
                }
            }
            else  if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
            {
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[11]);
                }
            }
            else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
            {
                if (transform.position.x < GameController._instance.npc.transform.position.x)
                {
                    if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[3]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                    {
                        transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[3]);
                    }
                }
                else
                {
                    if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
                     && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                    {
                        transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[10]);
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
        if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
        {
            if (transform.position.x < GameController._instance.npc.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                if (moveX == 1)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else if (moveX == -1)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
        else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
        {
            //if( GameController._instance.tagetBall.x < transform.position.x)
            // {
            //     if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false)
            //     transform.localScale = new Vector3(-1, 1, 1);
            // }
            //else
            // {
            //     transform.localScale = new Vector3(1, 1, 1);
            // }
            if (moveX == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveX == -1)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
    //    <1.75三分    >1.75 <4 投球2分   >4上篮或者灌篮
 
   public void Tiao()
    {
        if (GameController._instance.isstart == false) return;
        if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
        { 
            if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
            {
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[4]);
            }
        }
        else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.player)
        {
            if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
            && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
            {
                transform.localScale = new Vector3(1, 1, 1);
                if (transform.localPosition.x < 1.65f)
                { 
                    GameController._instance.isSanFenPlayer = true;
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[8]);
                }
                else if (transform.localPosition.x >= 1.65f && transform.localPosition.x < 4)
                {
                    GameController._instance.isSanFenPlayer = false;
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[8]);
                }
                else if (transform.localPosition.x >= 4)
                {
                    GameController._instance.isSanFenPlayer = false;
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(Random.Range(0,100) > 50 ? GameController._instance.animName[7] : GameController._instance.animName[9]);
                }
                GameController._instance.whoHaveBall = GameController.WhoHaveBall.none;
            }
        }
        else if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.npc)
        {
            if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == false
          && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == false
          && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false
          && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[7]) == false
          && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[8]) == false
          && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[9]) == false)
            {
                transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[4]);
            }
        }

          
    }

    public void StopPlay(bool isStop)
    { 
        if (isStop)
            transform.Find("playerFather/Armature").GetComponent<Animator>().speed = 0;
        else
            transform.Find("playerFather/Armature").GetComponent<Animator>().speed = 2;

    }
    
    

    public void ResAnimator()
    {
        transform.localScale = new Vector3(1, 1, 1);
        transform.Find("playerFather/Armature").GetComponent<Animator>().speed = 2;
        transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[0]);
    }

    public void QiangDao()
    {
        GameController._instance.whoHaveBall = GameController.WhoHaveBall.player;
        transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
    }

     

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ball"))
        {
            if (GameController._instance.whoHaveBall == GameController.WhoHaveBall.none)
            {
                GameController._instance.whoHaveBall = GameController.WhoHaveBall.player;
                GameController._instance.ballF.SetActive(false);
                if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[0]) == true
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
                else if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[4]) == true
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[6]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[6]);
                }
                else if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[5]) == true
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[1]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[1]);
                }
                else if (transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[10]) == true
                    && transform.Find("playerFather/Armature").GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName(GameController._instance.animName[11]) == false)
                {
                    transform.Find("playerFather/Armature").GetComponent<Animator>().Play(GameController._instance.animName[11]);
                } 
            }
        }
    }

   


}
