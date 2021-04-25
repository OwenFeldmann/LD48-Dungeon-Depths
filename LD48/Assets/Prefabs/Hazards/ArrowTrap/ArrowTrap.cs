using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    
	[SerializeField] Transform arrowSpawnPoint;
	[SerializeField] Arrow arrow;
	
	private bool canShoot = true;
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(canShoot && collision.gameObject.tag == "Player")
		{
			Instantiate(arrow, new Vector3(arrowSpawnPoint.position.x, arrowSpawnPoint.position.y, arrowSpawnPoint.position.z), Quaternion.identity, transform);
			canShoot = false;
			GetComponent<AudioSource>().Play();
		}
    }
	
}
