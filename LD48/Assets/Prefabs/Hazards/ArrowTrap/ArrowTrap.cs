using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    
    [Tooltip("Where arrows")]
	[SerializeField] private Transform arrowSpawnPoint;
    [Tooltip("Arrow prefab")]
	[SerializeField] private Arrow arrow;
	private bool canShoot = true;
	
	private void OnTriggerEnter2D(Collider2D collider)
    {
        if(canShoot)
		{
			Instantiate(arrow, new Vector3(arrowSpawnPoint.position.x, arrowSpawnPoint.position.y, arrowSpawnPoint.position.z), Quaternion.identity, transform);
			canShoot = false;
		}
    }
	
}
