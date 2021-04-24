using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
	
	[SerializeField] private Rigidbody2D rbChain;
	[SerializeField] private float rotationSpeed;
	
    // Start is called before the first frame update
    void Start()
    {
        rbChain.angularVelocity = rotationSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //TODO kill player
			Debug.Log("SpikeBall hit player");
        }
    }
}
