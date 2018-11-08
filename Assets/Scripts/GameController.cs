using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController UIController;
    public int enemyCount;


	public static GameController instance;
    
        void Awake()
        {
    
            if (!instance)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
            Initialisation();
        }
    
    
        public void Initialisation()
        {
        enemyCount = GameObject.Find("Enemies").transform.childCount;
            UIController.Initialisation();
        }
}
