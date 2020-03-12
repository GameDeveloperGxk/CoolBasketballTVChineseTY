using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class grade : MonoBehaviour {
    public static int redgrade = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = (redgrade+"");
    }
}
