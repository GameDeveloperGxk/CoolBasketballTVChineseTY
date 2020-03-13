using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCollider : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "ball")
        { 
            //UIManager._instance.audioManager.PlayOne(1);
        }
    }
 
}
