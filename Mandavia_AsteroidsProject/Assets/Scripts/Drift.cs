using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drift : MonoBehaviour
{
    // Drift script for larger asteroids

    // Fields
    // Necessary fields for storing velocity and direction
    public Vector3 direction;
    public float driftSpeed;
    public Vector3 objPosition;
    private GameObject forCollisions;
    private GameObject gameManager;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        direction = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        driftSpeed = Random.Range(4f, 8.5f + .5f * gameManager.GetComponent<ProgressManager>().difficulty);
        objPosition = transform.position;
        forCollisions = GameObject.Find("CollisionManager");
        forCollisions.GetComponent<CollisionDetector>().asteroids.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        objPosition += driftSpeed * new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        transform.position = objPosition;

        // Obtains camera values to determine screen bounds
        Camera view = Camera.current;
        float viewHeight = 2f * view.orthographicSize;
        float viewWidth = viewHeight * view.aspect;

        // Destroys the object if it is out of screen bounds
        if (transform.position.x > (viewWidth / 2 + gameObject.GetComponent<SpriteRenderer>().bounds.size.x * 3) || transform.position.x < (-viewWidth / 2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.x *  3) ||
                transform.position.y > (viewHeight / 2 + gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 3) || transform.position.y < (-viewHeight / 2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 3))
        {
            forCollisions.GetComponent<CollisionDetector>().asteroids.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
