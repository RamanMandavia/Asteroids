using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTravel : MonoBehaviour
{
    public float projectileSpeed;
    public Vector3 projPosition;
    private GameObject forCollisions;

	// Use this for initialization
	void Start ()
    {
        projectileSpeed = 9f;
        projPosition = transform.position;
        forCollisions = GameObject.Find("CollisionManager");
        forCollisions.GetComponent<CollisionDetector>().projectiles.Add(gameObject);
    }
	
	// Update is called once per frame
	void Update ()
    {
        projPosition += projectileSpeed * new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        transform.position = projPosition;

        // Obtains camera values to determine screen bounds
        Camera view = Camera.current;
        float viewHeight = 2f * view.orthographicSize;
        float viewWidth = viewHeight * view.aspect;

        // Destroys the object if it is out of screen bounds
        if (transform.position.x > viewWidth / 2 || transform.position.x < -viewWidth / 2 ||
                transform.position.y > viewHeight / 2 || transform.position.y < -viewHeight / 2)
        {
            forCollisions.GetComponent<CollisionDetector>().projectiles.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
