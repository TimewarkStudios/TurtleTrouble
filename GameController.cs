using System;

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{

	public GameObject hazardsManager;
	
	public Vector3 spawnValues;
//	public int hazardCount;
//	public float startWait;
//	public float spawnWait;
//	public float waveWait;


	public float ScrollSpeed;
	
	
	public GameObject FrontLayer;
	public GameObject ParallaxLayerFast;
	public GameObject ParallaxLayerSlow;
	public GameObject Background;

//	public GameObject Turtle;
//	private List<GameObject> Hazards;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool restart;
	public int score;

	// Use this for initialization
	void Start ()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		this.UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}

		//Front Layer
		foreach (Transform child in FrontLayer.transform)
		{
			child.position += Vector3.left * ScrollSpeed * Time.smoothDeltaTime;
		}

		//Parallax Fast Layer
		foreach (Transform child in ParallaxLayerFast.transform)
		{
			child.position += (Vector3.left * ScrollSpeed * Time.smoothDeltaTime) * 0.6f;
		}

		//Parallax Slow Layer
		foreach (Transform child in ParallaxLayerSlow.transform)
		{
			child.position += (Vector3.left * ScrollSpeed * Time.smoothDeltaTime) * 0.2f;
		}

		// Only if we can get a horizontally seamless background	
//		Background.transform.position += (Vector3.left * ScrollSpeed) * 0.1f;
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		this.UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		this.gameOverText.text = "Game Over";
		gameOver = true;
	}
}
