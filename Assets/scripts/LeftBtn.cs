using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftBtn : Button
{
    
	void Update ()
    {
        if (IsPressed() == true)
        {
            GameController._instance.player_script.MoveX = 1;
        }
        else
        {
            if (GameController._instance.player_script.MoveX == 1)
            {
                GameController._instance.player_script.MoveX = 0;
            }
        }
    }
}
