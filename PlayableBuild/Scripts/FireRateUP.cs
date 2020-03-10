using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUP : MonoBehaviour
{
    private GameObject player;
    public float timer = 10f;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Ship");
        player.GetComponent<ShipFire>().bulletCooldown -= .5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            player.GetComponent<ShipFire>().bulletCooldown += .5f;
            Destroy(this);
        }
	}
}
