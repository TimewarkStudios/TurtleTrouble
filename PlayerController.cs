using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}
	 

public class PlayerController : MonoBehaviour {
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;
    private int score;



    public float speed;
	public Boundary boundary = new Boundary();
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
    public CNAbstractController MovementJoystick;
    public void Shoot()
    {
        nextFire = Time.time + fireRate;
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audio.Play();
    }

	private float nextFire;

	void Update()
	{
        //if (Input.GetButton("Fire1") && Time.time > nextFire)
        //{
        
        //}

        float moveHorizontal = MovementJoystick.GetAxis("Horizontal");
        float moveVertical = MovementJoystick.GetAxis("Vertical");
        

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        rigidbody.velocity = Vector3.Lerp(movement * speed * Time.smoothDeltaTime, rigidbody.velocity, 0.3f);

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rigidbody.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        rigidbody.rotation = Quaternion.Lerp(
            Quaternion.Euler(((rigidbody.velocity.y * 4.0f - rigidbody.velocity.x) * tilt) + 2.0f, 90.0f, -100.0f),
            rigidbody.rotation,
            0.2f
        );
    }

	void FixedUpdate()
	{
		
	}
    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Pablo()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public static implicit operator PlayerController(PlayerController v)
    {
        throw new NotImplementedException();
    }
}

