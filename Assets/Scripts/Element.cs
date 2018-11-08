using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour {

    public bool isBreakble;
    public int health;

    public void CheckNDestroy()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        health--;
    }
	
    public static void CheckGameStatus()
    {
        if(Player.mainchar.health <=0)
        {
            GameController.instance.UIController.YouLose();
        }
        if(GameController.instance.enemyCount <= 0)
        {
            GameController.instance.UIController.YouWin();

        }
    }

}
