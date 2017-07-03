using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
	 

public class PlayerController : MonoBehaviour {
	private int score;

	public float speed;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public CNAbstractController MovementJoystick;

	private float nextFire;

	public void Shoot()
	{
		nextFire = Time.time + fireRate;
		Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		GetComponent<AudioSource>().Play();
	}

	void Update()
	{
		float moveHorizontal = MovementJoystick.GetAxis("Horizontal");
		float moveVertical = MovementJoystick.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody>().velocity = movement * speed;
		//if (rigidbody.velocity.magnitude > 0.3)
		//{
		//	Debug.Log("velocity: " + rigidbody.velocity.magnitude.ToString());
		//	Debug.Log("moveHorizontal: " + moveHorizontal.ToString());
		//	Debug.Log("moveHorizontal: " + moveVertical.ToString());
		//}
			

		GetComponent<Rigidbody>().rotation = Quaternion.Lerp(
			Quaternion.Euler(((GetComponent<Rigidbody>().velocity.y * 4.0f - GetComponent<Rigidbody>().velocity.x) * tilt) + 2.0f, 90.0f, -100.0f),
			GetComponent<Rigidbody>().rotation,
			0.2f
		);
	}

	void FixedUpdate()
	{
		
	}
	void Start()
	{
		score = 0;
		UpdateScore();
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore();
	}

	void UpdateScore()
	{
		//scoreText.text = "Score: " + score;
	}

	public void GameOver()
	{
		//gameOver = true;
		// Freeze Game
		// Show Game Over menu
	}

	
}

