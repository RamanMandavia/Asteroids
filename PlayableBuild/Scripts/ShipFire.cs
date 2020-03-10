using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFire : MonoBehaviour
{
    public GameObject bullet;
    private float bulletTimer;
    public float bulletCooldown;
    private bool readyToFire;

	// Use this for initialization
	void Start ()
    {
        readyToFire = true;
        bulletTimer = 0;
        bulletCooldown = .65f;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
        {
            if (readyToFire)
            {
                Instantiate(bullet, gameObject.transform.position, Quaternion.Euler(gameObject.GetComponent<ShipMovementControl>().direction));
                readyToFire = false;
            }
        }

        if (!readyToFire)
        {
            bulletTimer += Time.deltaTime;

            if (bulletTimer >= bulletCooldown)
                bulletTimer = 0f;

            if (bulletTimer == 0f)
            {
                readyToFire = true;
            }
        }
    }
}
