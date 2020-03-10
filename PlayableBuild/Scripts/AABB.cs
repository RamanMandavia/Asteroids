using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AABB : MonoBehaviour
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
        if (((object1.GetComponent<SpriteRenderer>().bounds.center.x + object1.GetComponent<SpriteRenderer>().bounds.extents.x) > (object2.GetComponent<SpriteRenderer>().bounds.center.x - object2.GetComponent<SpriteRenderer>().bounds.extents.x))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.x - object1.GetComponent<SpriteRenderer>().bounds.extents.x) < (object2.GetComponent<SpriteRenderer>().bounds.center.x + object2.GetComponent<SpriteRenderer>().bounds.extents.x))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.y + object1.GetComponent<SpriteRenderer>().bounds.extents.y) > (object2.GetComponent<SpriteRenderer>().bounds.center.y - object2.GetComponent<SpriteRenderer>().bounds.extents.y))
            && ((object1.GetComponent<SpriteRenderer>().bounds.center.y - object1.GetComponent<SpriteRenderer>().bounds.extents.y) < (object2.GetComponent<SpriteRenderer>().bounds.center.y + object2.GetComponent<SpriteRenderer>().bounds.extents.y)))
        { return true; }
        else
        { return false; }
    }
}
