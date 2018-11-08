using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int speed = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.eulerAngles.y >= 0 && transform.eulerAngles.y < 90)
        {
            transform.position += Vector3.forward * -1 * speed * Time.deltaTime;
        }
        if (transform.eulerAngles.y >= 90 && transform.eulerAngles.y < 180)
        {
            transform.position += Vector3.right * -1 * speed * Time.deltaTime;
        }
       if(transform.eulerAngles.y >= 180 && transform.eulerAngles.y < 270)
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (transform.eulerAngles.y >= 270 && transform.eulerAngles.y < 360)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Barrier")
        {
            if(other.GetComponent<Element>().isBreakble == true)
            {
                other.GetComponent<Element>().TakeDamage();
                other.GetComponent<Element>().CheckNDestroy();
            }
            Destroy(gameObject);
        }
        else if(other.tag == "EasyTower")
        {
            other.GetComponent<EasyTower>().TakeDamage();
            other.GetComponent<EasyTower>().CheckNDestroy();
            Destroy(gameObject);
        }
        else if(other.tag == "HardTower")
        {
            other.GetComponent<HardTower>().TakeDamage();
            other.GetComponent<HardTower>().CheckNDestroy();
            Destroy(gameObject);
        }
        else if(other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage();
            other.GetComponent<Player>().CheckNDestroy();
            Destroy(gameObject);
            Destroy(GameController.instance.UIController.lifes[other.GetComponent<Player>().health].gameObject);
            Element.CheckGameStatus();
        }
    }

}
