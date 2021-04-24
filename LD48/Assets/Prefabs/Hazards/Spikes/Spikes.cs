using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    
	private void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collides with trigger, they take damage, and projectile disappears
        if(collision.gameObject.tag == "Player")
        {
            //TODO kill player
			Debug.Log("Player dies to spikes");
        }
    }
	
}
