using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
	private PlayerController playerController;
   

	void Start()
	{
		 playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

    }

	void OnTriggerEnter(Collider other)
	{
	    
	    if (other.tag == "Player")
	    {
	        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
		    playerController.GameOver();
	    }

	    
		
	}
}
