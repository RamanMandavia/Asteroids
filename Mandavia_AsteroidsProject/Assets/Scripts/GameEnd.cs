using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private GameObject gameManager;
    public Text warningT;
    public Text gameOverT;
    public Text replayPromtT;
    public Text finalScoreT;
    public Text survTimeT;
    public Text finalScoreNum;
    public Text survTimeNum;

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.Find("GameManager");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (!gameManager.GetComponent<ProgressManager>().enabled)
        {
            warningT.GetComponent<Text>().enabled = false;
            survTimeNum.text = "" + Mathf.Round(gameManager.GetComponent<ProgressManager>().survTime);
            finalScoreNum.text = "" + gameManager.GetComponent<ProgressManager>().score;
            gameOverT.GetComponent<Text>().enabled = true;
            replayPromtT.GetComponent<Text>().enabled = true;
            finalScoreT.GetComponent<Text>().enabled = true;
            survTimeT.GetComponent<Text>().enabled = true;
            finalScoreNum.GetComponent<Text>().enabled = true;
            survTimeNum.GetComponent<Text>().enabled = true;

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.UnloadSceneAsync(1);
                SceneManager.LoadScene(0);
            }
        }
	}
}
