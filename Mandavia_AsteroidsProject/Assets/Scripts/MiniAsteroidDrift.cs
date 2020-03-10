using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAsteroidDrift : MonoBehaviour
{
    // Drift script for mini asteroids

    // Fields
    // Necessary fields for storing velocity and direction
    public Vector3 direction;
    public float driftSpeed;
    public Vector3 objPosition;
    private GameObject forCollisions;
    public float fuckThis;

    // Use this for initialization
    void Start()
    {
        forCollisions = GameObject.Find("CollisionManager");
        direction = new Vector3(transform.rotation.normalized.x + Random.Range(-.0033f, .0033f), transform.rotation.normalized.y + Random.Range(-.003f, .003f), transform.rotation.z);
        objPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        objPosition += driftSpeed * direction;
        transform.position = objPosition;

        // Obtains camera values to determine screen bounds
        Camera view = Camera.current;
        float viewHeight = 2f * view.orthographicSize;
        float viewWidth = viewHeight * view.aspect;

        // Destroys the object if it is out of screen bounds
        if (transform.position.x > (viewWidth / 2 + gameObject.GetComponent<SpriteRenderer>().bounds.size.x * 3) || transform.position.x < (-viewWidth / 2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.x * 3) ||
                transform.position.y > (viewHeight / 2 + gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 3) || transform.position.y < (-viewHeight / 2 - gameObject.GetComponent<SpriteRenderer>().bounds.size.y * 3))
        {
            forCollisions.GetComponent<CollisionDetector>().miniAsteroids.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
