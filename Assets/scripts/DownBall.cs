using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBall : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        { 
            GameController._instance.whoHaveBall = GameController.WhoHaveBall.player;
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("npc"))
        {
            GameController._instance.whoHaveBall = GameController.WhoHaveBall.npc;
            gameObject.SetActive(false);
        }
    }
}
