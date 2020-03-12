using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBone;

public class Demo : MonoBehaviour {

    private Animator animator;


    private void Start()
    {
        animator =transform.Find("playerFather/Armature").GetComponent<Animator>();
      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("daiji");
        }
        if (Input.GetKeyDown(KeyCode.S ))
        {
            animator.Play("daiji_daiqiu");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.Play("daiji_meiqiu");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.Play("fangshou");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.Play("fangshou_yidong");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            animator.Play("qiang_meiqiu");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.Play("qiang_youqiu");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.Play("tiaoqi");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            animator.Play("touqiu_guanlan");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.Play("touqiu_sanfenqiu");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.Play("touqiu_shanglan");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.Play("zou");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            animator.Play("zou_qiu");
        }


    }
}
