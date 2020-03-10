using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour
{
    private GameObject gameManager;
    public Vector3 objScale;

	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.Find("GameManager");
        int difficutly = gameManager.GetComponent<ProgressManager>().difficulty;
        objScale = Vector3.one * Random.Range(.75f + .1f * difficutly, 1.5f + .1f * difficutly);
        transform.localScale = objScale;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
