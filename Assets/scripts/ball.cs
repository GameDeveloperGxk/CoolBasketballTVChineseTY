using UnityEngine;
using System.Collections;

public class ball : MonoBehaviour {
    float speed = 700f;  
    void OnEnable()
    {
    //    if (GameController._instance.isStop) return;
        transform.localPosition = new Vector2(0.06f,-1.48f);
        GetComponent<Rigidbody2D>().Sleep();
        StartCoroutine(run());
    //    GameController._instance.Ball = gameObject;

    }
     

    IEnumerator run()
    {
        yield return new WaitForSeconds(1f); 
        UIManager._instance.audioManager.PlayOne(0);
        GetComponent<Rigidbody2D>().WakeUp();
        GetComponent<Rigidbody2D>().velocity =  Vector2.up * speed;

        yield return new WaitForSeconds(1f);

        GameController._instance.isstart = true;
    }

    
}
