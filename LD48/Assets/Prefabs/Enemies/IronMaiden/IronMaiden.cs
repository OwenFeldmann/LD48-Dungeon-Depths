using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronMaiden : MonoBehaviour
{
	
	private float jumpForceY = 5;
	private float jumpforceX = 3;
	private bool onGround = true;
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			onGround = true;
		}
		else if(collision.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().die();
		}
	}
	
	private void OnCollisionExit2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			onGround = false;
		}
	}
	
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			if(onGround)
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
}
