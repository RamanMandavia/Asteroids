using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDivision : MonoBehaviour
{
    private GameObject collisionManager;
    public GameObject divAsteroid;

	// Use this for initialization
	void Start ()
    {
        collisionManager = GameObject.Find("CollisionManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Divide()
    {

        float scaleDiminish1 = Random.Range(.3f, .7f);
        float scaleDiminish2 = Random.Range(.3f, .7f);
        Vector3 divAsteroid1scale = new Vector3(scaleDiminish1, scaleDiminish1, scaleDiminish1);
        Vector3 divAsteroid2scale = new Vector3(scaleDiminish2, scaleDiminish2, scaleDiminish2);

        float divAsteroid1speed = gameObject.GetComponent<Drift>().driftSpeed + Random.Range(-2.5f, .5f);
        float divAsteroid2speed = gameObject.GetComponent<Drift>().driftSpeed + Random.Range(-2.5f, .5f);

        // Instantiates the first mini asteroid and sets its scale and speed
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Add(Instantiate(
            divAsteroid, transform.position, transform.rotation));
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids[collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Count - 1].
            transform.localScale = divAsteroid1scale;
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids[collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Count - 1].
            GetComponent<MiniAsteroidDrift>().driftSpeed = divAsteroid1speed;

        // Instantiates the second mini asteroid and sets its scale and speed
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Add(Instantiate(
            divAsteroid, transform.position, transform.rotation));
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids[collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Count - 1].
            transform.localScale = divAsteroid2scale;
        collisionManager.GetComponent<CollisionDetector>().miniAsteroids[collisionManager.GetComponent<CollisionDetector>().miniAsteroids.Count - 1].
            GetComponent<MiniAsteroidDrift>().driftSpeed = divAsteroid2speed;

        Destroy(gameObject);
    }
}
