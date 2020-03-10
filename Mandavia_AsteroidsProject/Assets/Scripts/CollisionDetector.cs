using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public List<GameObject> asteroids; // List of larger, initial asteroids
    public List<GameObject> miniAsteroids; // List of smaller, split-off asteroids
    public List<GameObject> projectiles; // List of all projectiles
    public List<GameObject> fireRateUPS; // List of fire rate pickups
    public List<GameObject> timeSlows; // List of time slow pickups
    public GameObject player;
    public GameObject gameManager;

    public GameObject fireRateUpPickup;
    public GameObject timeSlowPickup;

    // Fields for pickup drops
    // Determins if there is a pickup and what type it will be
    public int pickupDropNum1;
    public int pickupDropNum2;
    public int pickupType;      // 1 is for fire rate, 2 is for time slow, 0 is none

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Ship");
        gameManager = GameObject.Find("GameManager");
        pickupType = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Pickup rolls
        pickupDropNum1 = Random.Range((int)0, (int)101);
        if (45 < pickupDropNum1 && pickupDropNum1 < 67)
        {
            pickupDropNum2 = Random.Range((int)0, (int)101);
            if (pickupDropNum2 > 25 && pickupDropNum2 < 50)
                pickupType = 1;
            else if (pickupDropNum2 > 60 && pickupDropNum2 < 73)
                pickupType = 2;
            else
                pickupType = 0;
        }
        else
            pickupType = 0;
        

        foreach (GameObject asteroid in asteroids)
        {
            foreach(GameObject proj in projectiles)
            {
                if(gameObject.GetComponent<BoundingCirc>().CheckCollision(asteroid, proj))
                {
                    if (pickupType == 1)
                    {
                        fireRateUPS.Add(Instantiate(fireRateUpPickup, proj.transform.position, Quaternion.identity));
                    }
                    
                    if (pickupType == 2)
                    {
                        timeSlows.Add(Instantiate(timeSlowPickup, proj.transform.position, Quaternion.identity));
                    }
                    
                    projectiles.Remove(proj);
                    Destroy(proj);
                    asteroid.GetComponent<AsteroidDivision>().Divide();
                    asteroids.Remove(asteroid);
                    gameManager.GetComponent<ProgressManager>().score += 20;
                }
            }

            if (gameObject.GetComponent<BoundingCirc>().CheckCollision(asteroid, player))
            {
                if (player.GetComponent<TakeDamage>().isDamaged == false)
                {
                    player.GetComponent<ShipHealth>().health -= 20;
                    player.GetComponent<TakeDamage>().isDamaged = true;
                    asteroid.GetComponent<AsteroidDivision>().Divide();
                    asteroids.Remove(asteroid);
                }
            }
        }

        foreach (GameObject miniAsteroid in miniAsteroids)
        {
            foreach (GameObject proj in projectiles)
            {
                if (gameObject.GetComponent<BoundingCirc>().CheckCollision(miniAsteroid, proj))
                {
                    if (pickupType == 1)
                    {
                        fireRateUPS.Add(Instantiate(fireRateUpPickup, proj.transform.position, Quaternion.identity));
                    }

                    if (pickupType == 2)
                    {
                        timeSlows.Add(Instantiate(timeSlowPickup, proj.transform.position, Quaternion.identity));
                    }

                    projectiles.Remove(proj);
                    Destroy(proj);
                    miniAsteroids.Remove(miniAsteroid);
                    Destroy(miniAsteroid);
                    gameManager.GetComponent<ProgressManager>().score += 50;
                }
            }

            if (gameObject.GetComponent<BoundingCirc>().CheckCollision(miniAsteroid, player))
            {
                if (player.GetComponent<TakeDamage>().isDamaged == false)
                {
                    player.GetComponent<ShipHealth>().health -= 10;
                    player.GetComponent<TakeDamage>().isDamaged = true;
                    miniAsteroids.Remove(miniAsteroid);
                    Destroy(miniAsteroid);
                }
            }
        }

        foreach (GameObject pickup in fireRateUPS)
        {
            if (gameObject.GetComponent<BoundingCirc>().CheckCollision(pickup, player))
            {
                // If the powerup is not active, adds it on.
                // If it is, stacks onto the timer
                if (player.GetComponent<FireRateUP>() == null)
                    player.AddComponent<FireRateUP>();
                else
                    player.GetComponent<FireRateUP>().timer += 10f;
                fireRateUPS.Remove(pickup);
                Destroy(pickup);
            }
        }

        foreach(GameObject pickup in timeSlows)
        {
            if (gameObject.GetComponent<BoundingCirc>().CheckCollision(pickup, player))
            {
                // Becuase time slow is instance-based, stacking the timer doesn't
                // achieve all that much, so picking one up while another is active does
                // nothing
                if (gameObject.GetComponent<TimeSlow>() == null)
                    gameObject.AddComponent<TimeSlow>();
                timeSlows.Remove(pickup);
                Destroy(pickup);
            }
        }
    }
}
