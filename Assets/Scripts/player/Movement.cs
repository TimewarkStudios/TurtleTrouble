using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour {

    public float speed;
    private Vector3 targetVelocity;

    public void MoveUp()
    {
        targetVelocity.y = speed;
    }
    public void StopMoveUp()
    {
        targetVelocity.y = 0;
    }
    public void MoveDown()
    {
        targetVelocity.y = -speed;
    }
    public void StopMoveDown()
    {
        targetVelocity.y = 0;
    }
    public void MoveLeft()
    {
        targetVelocity.x = -speed;
    }
    public void StopMoveLeft()
    {
        targetVelocity.x = 0;
    }
    public void MoveRight()
    {
        targetVelocity.x = speed;
    }
    public void StopMoveRight()
    {
        targetVelocity.x = 0;
    }

  
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity = Vector3.Lerp(targetVelocity * speed * Time.smoothDeltaTime, GetComponent<Rigidbody>().velocity, 0.3f);
    }
}
