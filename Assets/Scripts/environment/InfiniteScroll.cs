using UnityEngine;
using System.Collections;

public class InfiniteScroll : MonoBehaviour
{

	public float ScrollDistance;
	public float ScrollOffset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.transform.position.x <= -ScrollDistance + ScrollOffset)
		{ 
			gameObject.transform.position = new Vector3(
				gameObject.transform.position.x + ScrollOffset + ScrollDistance * 2,
				gameObject.transform.position.y,
				gameObject.transform.position.z
			);
		}
	}
}
