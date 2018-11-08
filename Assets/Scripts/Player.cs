using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Element, Shootable
{

    public int speed;

    public GameObject bullet;
    public Transform shootpoint;


    public static Player mainchar;

    void Awake()
    {

        if (!mainchar)
        {
            mainchar = this;
        }
        else if (mainchar != this)
        {
            Destroy(gameObject);
        }
        Initialisation();
    }

    public void Initialisation()
    {
        speed = 4;
        health = 6;
    }
   
	void Update () {

        if(Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.position += Vector3.forward * speed * Time.deltaTime;
            shootpoint.eulerAngles = shootpoint.parent.eulerAngles;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
            shootpoint.eulerAngles = shootpoint.parent.eulerAngles;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position += Vector3.forward * -1 * speed * Time.deltaTime;
            shootpoint.eulerAngles = shootpoint.parent.eulerAngles;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.position += Vector3.right * -1 * speed * Time.deltaTime;
            shootpoint.eulerAngles = shootpoint.parent.eulerAngles;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
		
	}


    public void Shoot()
    {
        Instantiate(bullet, shootpoint.position, Quaternion.Euler(shootpoint.parent.eulerAngles.x, shootpoint.parent.eulerAngles.y, shootpoint.parent.eulerAngles.z));
    }

}
