using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(-5 * transform.parent.localScale.x, 0);
		Destroy(gameObject, 1.0f);
    }
	
	private void OnTriggerEnter2D(Collider2D collision)
    {
        // When player collides with trigger, they take damage, and projectile disappears
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().die();
            Destroy(this.gameObject);
        }
		else if(collision.gameObject.tag == "Ground")
		{
			Destroy(this.gameObject);
		}
    }
	
}
