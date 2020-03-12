using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class text : MonoBehaviour {
    public static int bluegrade = 0;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = (bluegrade + "");
    }
}
