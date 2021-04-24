using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
	
	private float direction = -1;
	private float moveSpeed = 5;
	private int counter = 0;
	private Rigidbody2D rb;
	
	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update()
    {
        counter++;
		
		rb.velocity = new Vector2(direction * moveSpeed, 1.5f * Mathf.Sin(counter / 5));
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().die();
        }
		else if(collision.gameObject.tag == "Ground")
		{
			Flip();
		}
    }
	
	private void Flip()
	{
		direction *= -1;
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
}
