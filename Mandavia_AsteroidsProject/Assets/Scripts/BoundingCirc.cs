using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingCirc : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public bool CheckCollision(GameObject object1, GameObject object2)
    {
        if (Mathf.Pow((Mathf.Pow((object2.GetComponent<SpriteRenderer>().bounds.center.x - object1.GetComponent<SpriteRenderer>().bounds.center.x), 2.0f) + Mathf.Pow((object2.GetComponent<SpriteRenderer>().bounds.center.y - object1.GetComponent<SpriteRenderer>().bounds.center.y), 2.0f)), 2.0f)
            < (Mathf.Pow((object1.GetComponent<SpriteRenderer>().bounds.extents.x + object2.GetComponent<SpriteRenderer>().bounds.extents.x), 2.0f)))
        { return true; }
        else
        { return false; }
    }
}
