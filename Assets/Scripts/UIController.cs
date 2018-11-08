using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public GameObject[] lifes = new GameObject[6];
    public GameObject winPanel, losePanel;

    public void YouWin()
    {
        winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void YouLose()
    {
        losePanel.SetActive(true);
        Time.timeScale = 0f;

    }


    public void Initialisation()
    {

    }
}
