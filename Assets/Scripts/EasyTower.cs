using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyTower : Element, Shootable
{
    public Transform shootpoint;
    public GameObject bullet;
    public bool isOnTrig;

	void Start () {
        isBreakble = true;
        health = 3;
        isOnTrig = false;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnTrig = true;
            StartCoroutine(Shooting());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isOnTrig = false;
        }
    }


    public void Shoot()
    {
        Instantiate(bullet, shootpoint.position, Quaternion.Euler(shootpoint.eulerAngles.x, shootpoint.eulerAngles.y, shootpoint.eulerAngles.z));
    }

    IEnumerator Shooting()
    {
        while (isOnTrig)
        {
            Shoot();
            yield return new WaitForSeconds(1f);
        }
    }

    new public void CheckNDestroy()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            GameController.instance.enemyCount--;
            Element.CheckGameStatus();
        }
    }


}
