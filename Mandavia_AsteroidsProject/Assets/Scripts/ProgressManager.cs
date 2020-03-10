using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    // Contains Score and Level Progress information
    // Score is simply tracked, while level progress is based on the time
    // that the player has survived
    public int score;
    public Text scoreDisplay;
    public float survTime;
    public float difficultyScaleTime;
    // 6 tiers of difficulty, including the starting difficulty
    // The player moves to the next tier after surviving
    // for 12 seconds. An increase in difficulty causes
    // asteroids to spawn more frequently and at greater
    // scalar values
    public int difficulty;

    // Image for the warning icon, along with a timer for its duration and
    // flashes
    public Text warning;
    public float displayTime;
    public float flashTime;
    public bool displayWarning;
    private bool flickerState; // true is on, false is off

    // Use this for initialization
    void Start ()
    {
        score = 0;
        survTime = 0;
        difficultyScaleTime = 0; ;
        difficulty = 0; // The initial difficutly is 0, the max is 5

        displayWarning = false;
        flickerState = false;
        displayTime = 0;
        flashTime = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        survTime += Time.deltaTime;
        difficultyScaleTime += Time.deltaTime;

        scoreDisplay.text = "" + score;

        if (difficultyScaleTime >= 12)
        {
            difficulty++;

            gameObject.GetComponent<AsteroidSpawn>().spawnTimerMax -= .25f;

            difficultyScaleTime = 0;

            displayWarning = true;
            flickerState = true;
        }

        if (displayWarning)
        {
            displayTime += Time.deltaTime;
            flashTime += Time.deltaTime;

            if (flashTime >= .5f)
            {
                flickerState = !flickerState;
                flashTime = 0;
            }

            if (flickerState)
                warning.color = new Color(1f, 0f, 0f, 1.0f);

            if (!flickerState)
                warning.color = new Color(1f, 0f, 0f, 0f);

            if (displayTime >= 2f)
            {
                displayWarning = false;
                flickerState = false;
                displayTime = 0;
                flashTime = 0;
            }
        }
	}
}
