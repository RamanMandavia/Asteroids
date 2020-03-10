using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeSlow : MonoBehaviour
{
    private GameObject monochrome;
    public float timer = 10f;
    private List<GameObject> lAsteroids;
    private List<GameObject> mAsteroids;

	// Use this for initialization
	void Start ()
    {
        monochrome = GameObject.Find("Monochrome");

        lAsteroids = gameObject.GetComponent<CollisionDetector>().asteroids;
        mAsteroids = gameObject.GetComponent<CollisionDetector>().miniAsteroids;

        // Slows down the speed of every asteroid in both large and small asteroid lists in the collision
        // detector. This script is attached to the collision manager, making this slightly easier
        // This is done one startup, so only the asteroids that exist when the script is active are affected
        if (timer > 0f)
        {
            monochrome.GetComponent<Image>().enabled = true;

            foreach (GameObject asteroid in lAsteroids)
            {
                asteroid.GetComponent<Drift>().driftSpeed -= 2.0f;
            }
            foreach (GameObject asteroid in mAsteroids)
            {
                asteroid.GetComponent<MiniAsteroidDrift>().driftSpeed -= 2.0f;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        // Returns asteroid speeds to normal
        if (timer <= 0f)
        {
            monochrome.GetComponent<Image>().enabled = false;

            Destroy(this);
        }
	}
}
