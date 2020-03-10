using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int health;
    public Slider healthSlider;
    private GameObject gameManager;

	// Use this for initialization
	void Start ()
    {
        health = 100;
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
        healthSlider.value = health;

        if (health <= 0)
        {
            gameManager.GetComponent<AsteroidSpawn>().enabled = false;
            gameManager.GetComponent<ProgressManager>().displayWarning = false;
            gameManager.GetComponent<ProgressManager>().enabled = false;
            Destroy(gameObject);
        }
	}
}
