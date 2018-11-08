using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardTower : Element, Shootable
{
    public Ray[] rays = new Ray[4];
    public GameObject bullet;
    public Transform [] shootpoints = new Transform[4];
    public float distance;
    public Transform shootpoint;
    public float nexstSpawnTime;


	// Use this for initialization
	void Start () {
        nexstSpawnTime = 1f;
        distance = 4f;
        rays[0] = new Ray(transform.position, transform.forward);
        rays[1] = new Ray(transform.position, transform.forward * -1);
        rays[2] = new Ray(transform.position, transform.right);
        rays[3] = new Ray(transform.position, transform.right * -1);
    }
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        for(int i=0; i< rays.Length; i++)
        {
            if(Physics.Raycast(rays[i], out hit, distance))
            {
               if(hit.collider.tag == "Player")
                {
                    if(Time.time >= nexstSpawnTime)
                    {
                        shootpoint = shootpoints[i];
                        Shoot();
                        nexstSpawnTime = Time.time + 1f;
                    }
                    
                }
            }
        }
		
	}

    public void Shoot()
    {
        Instantiate(bullet, shootpoint.position, Quaternion.Euler(shootpoint.eulerAngles.x, shootpoint.eulerAngles.y, shootpoint.eulerAngles.z));
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
