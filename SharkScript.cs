using System;

using UnityEngine;
using System.Collections;


public class SharkScript : MonoBehaviour
{
	public GameController GameController;
	public GameObject Player;

	public float BobHeight;
	public float BobSpeed = 0.05f;

	public float ChargeSpeedMultiplier;
	public float ChargeBobMultiplier;
	public float WaitForChaseSeconds;

	private float gameSpeed;
	private float initY;
	private float bobSpeed;
	private float bobHeight;
	private bool hasCharged;



	// Use this for initialization
	void Start ()
	{
		gameSpeed = GameController.ScrollSpeed;
		initY = transform.position.y;
		bobSpeed = BobSpeed;
		bobHeight = BobHeight;
		rigidbody.velocity = new Vector3(-gameSpeed, 0.0f, 0.0f);
		hasCharged = false;
	}
	
	// Update is called once per frame
	void Update () {
		//switch
		if (transform.position.y - initY > bobHeight || transform.position.y - initY < -bobHeight)
		{
			bobSpeed = -bobSpeed;
		}

		if (!hasCharged && this.transform.position.x < 7)
		{
			StartCoroutine("WiggleAndCharge");
			hasCharged = true;

		}

		if (this.transform.position.x < -20)
		{
			Destroy(this.gameObject);
		}

		//animate
		transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.up * bobHeight, bobSpeed);
	}

	IEnumerator WiggleAndCharge()
	{
		rigidbody.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		yield return new WaitForSeconds(WaitForChaseSeconds / 2.0f);
		bobSpeed *= ChargeBobMultiplier;
		bobHeight *= ChargeBobMultiplier;
		Debug.Log(bobSpeed);
		yield return new WaitForSeconds(WaitForChaseSeconds / 2.0f);
		
		rigidbody.velocity = new Vector3(-gameSpeed * ChargeSpeedMultiplier, 0.0f, 0.0f);
		yield return null;
	}
}
