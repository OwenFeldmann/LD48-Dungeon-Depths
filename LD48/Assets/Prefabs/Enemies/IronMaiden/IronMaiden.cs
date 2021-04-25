using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMaiden : MonoBehaviour
{
	
	[SerializeField] LayerMask groundMask;
	
	private float jumpForceY = 5;
	private float jumpforceX = 3;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().die();
		}
		else if(collision.gameObject.tag == "Ground")
		{
			if((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude <= 10)
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
	
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			if(OnGround())
			{
				if(collision.gameObject.transform.position.x < transform.position.x)
				{
					//jump left
					GetComponent<Rigidbody2D>().velocity = new Vector2(-jumpforceX, jumpForceY);
				}
				else
				{
					//jump right
					GetComponent<Rigidbody2D>().velocity = new Vector2(jumpforceX, jumpForceY);
				}
			}
		}
	}
	
	private bool OnGround()
	{
		return Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.01f, groundMask).collider != null;
	}
}
