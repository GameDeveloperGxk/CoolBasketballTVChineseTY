using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBall : MonoBehaviour
{ 

    public Transform showTu;

    private GameObject target;   //要到达的目标

    public float speed = 10;    //速度
    private float distanceToTarget;   //两者之间的距离
    private bool move = true;

    public bool SetMove { get { return move; } set { move = value; } }
    private void Update()
    {
        showTu.position = transform.position;
    }


    public void Move(GameObject startObj,GameObject targetObj)
    {
        move = true;
        GameController._instance.targetObj = targetObj;
        this.transform.position = startObj.transform.position;
        target = targetObj;
        //计算两者之间的距离
        distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
        StartCoroutine(StartShoot());
    }

   public  IEnumerator StartShoot()
    {

        while (move)
        {
            Vector3 targetPos = target.transform.position;

            //让始终它朝着目标
            this.transform.LookAt(targetPos);

            //计算弧线中的夹角
            float angle = Mathf.Min(1, Vector3.Distance(this.transform.position, targetPos) / distanceToTarget) * 45;
            this.transform.rotation = this.transform.rotation * Quaternion.Euler(Mathf.Clamp(-angle, -42, 42), 0, 0);
            float currentDist = Vector3.Distance(this.transform.position, target.transform.position);
             if (GameController._instance.isstart == false)
                 move = false;
            this.transform.Translate(Vector3.forward * Mathf.Min(speed * Time.deltaTime, currentDist));
            yield return null;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Right"))
        {
            transform.parent.gameObject.SetActive(false);
            int a = UnityEngine.Random.Range(0, 100);
            bool isIn = false;
            if (a > 55)
            {
                isIn = false;
            }
            else
            {
                isIn = true;
            }
            GameController._instance.isShootInPlayer = isIn;
            GameController._instance.rightLankuang.Play(isIn);
        }
        if (collision.gameObject.CompareTag("Left"))
        {
            transform.parent.gameObject.SetActive(false);
            int a = UnityEngine.Random.Range(0, 100);
            bool isIn = false;
            if (a > 55)
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





}
