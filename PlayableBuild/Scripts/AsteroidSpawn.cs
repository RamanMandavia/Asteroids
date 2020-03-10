using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour
{
    // Values for camera, width and height
    // This sets the camera view bounds, to allow random spawning
    // of asteroids from outside of the camera. These will then
    // travel in a random direction based on spawn point
    private Camera view;
    private float viewHeight;
    private float viewWidth;
    public float spawnTimer;
    public float spawnTimerMax;
    public GameObject[] asteroids;
    public Vector3 objPosition;
    public Vector3 objDirection;

    // Use this for initialization
    void Start ()
    {
        spawnTimer = 0;
        spawnTimerMax = 1.75f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        view = Camera.current;
        viewHeight = 2f * view.orthographicSize;
        viewWidth = viewHeight * view.aspect;

        spawnTimer += Time.deltaTime;

        // Spawns asteroids at intervals based on the current spawn timer's max
        if(spawnTimer >= spawnTimerMax)
        {
            // A random number paired with a switch statement
            // to determine where the object will spawn. Each of
            // the four sides of the screen have 3 sections where
            // an asteroid can spawn, which will also determine
            // their drift direction
            // Also determines which asteroid will be spawned
            int rand = Random.Range((int)1, (int)13);
            GameObject asteroidSelection = asteroids[Random.Range(0, asteroids.Length)];

            switch (rand)
            {
                // Top section of the screen
                case 1:
                    // The height width value of the asteroid is scaled by 2 due to the fact that asteroids are scaled to varying sizes
                    // as the game progresses, the maximum scale size being 2.5. This way, these especially large asteroids are visible
                    // as they spawn in
                    objPosition = new Vector3(Random.Range(-viewWidth / 2, (-viewWidth / 2) * .67f), 
                        viewHeight / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(.3f, .75f), Random.Range(-.9f, -.25f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 2:
                    objPosition = new Vector3(Random.Range((-viewWidth / 2) * .67f, (viewWidth / 2) * .33f), 
                        viewHeight / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(-.65f, .65f), Random.Range(-.9f, -.25f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 3:
                    objPosition = new Vector3(Random.Range((viewWidth / 2) * .33f, (viewWidth / 2)), 
                        viewHeight / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(-.75f, -.3f), Random.Range(-.9f, -.25f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;

                // Bottom section of the screen
                case 4:
                    objPosition = new Vector3(Random.Range(-viewWidth / 2, (-viewWidth / 2) * .67f), 
                        -viewHeight / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(.3f, .75f), Random.Range(.25f, .9f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 5:
                    objPosition = new Vector3(Random.Range((-viewWidth / 2) * .67f, (viewWidth / 2) * .33f),
                        -viewHeight / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(-.65f, .65f), Random.Range(.25f, .9f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 6:
                    objPosition = new Vector3(Random.Range((viewWidth / 2) * .33f, (viewWidth / 2)),
                        -viewHeight / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.y * 2, 0);
                    objDirection = new Vector3(Random.Range(-.75f, -.3f), Random.Range(.25f, .9f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                
                // Right section of the screen
                case 7:
                    objPosition = new Vector3(viewWidth / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range(-viewHeight / 2, (-viewHeight / 2) * .67f), 0);
                    objDirection = new Vector3(Random.Range(-.9f, -.25f), Random.Range(.4f, .75f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 8:
                    objPosition = new Vector3(viewWidth / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range((-viewHeight / 2) * .67f, (viewHeight / 2) * .33f), 0);
                    objDirection = new Vector3(Random.Range(-.9f, -.25f), Random.Range(-.65f, .65f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 9:
                    objPosition = new Vector3(viewWidth / 2 + asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range((viewHeight / 2) * .33f, (viewHeight / 2)), 0);
                    objDirection = new Vector3(Random.Range(-.9f, -.25f), Random.Range(-.75f, -.4f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;

                // Left section of the screen
                case 10:
                    objPosition = new Vector3(-viewWidth / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range(-viewHeight / 2, (-viewHeight / 2) * .67f), 0);
                    objDirection = new Vector3(Random.Range(.25f, .9f), Random.Range(.4f, .75f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 11:
                    objPosition = new Vector3(-viewWidth / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range((-viewHeight / 2) * .67f, (viewHeight / 2) * .33f), 0);
                    objDirection = new Vector3(Random.Range(.25f, .9f), Random.Range(-.65f, .65f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
                case 12:
                    objPosition = new Vector3(-viewWidth / 2 - asteroidSelection.GetComponent<SpriteRenderer>().bounds.size.x * 2,
                        Random.Range((viewHeight / 2) * .33f, (viewHeight / 2)), 0);
                    objDirection = new Vector3(Random.Range(.25f, .9f), Random.Range(-.75f, -.4f), 0);
                    Instantiate(asteroidSelection, objPosition, Quaternion.Euler(objDirection));
                    break;
            }

            spawnTimer = 0;
        }
	}
}
