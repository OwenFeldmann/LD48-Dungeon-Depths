using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.angularVelocity = 500f * Random.Range(.5f, 1f) * (Random.Range(0, 2) * 2 - 1);
		rb.velocity = new Vector2(0, -1);
    }
	
	void Update()
	{
		if(GetComponent<Rigidbody2D>().velocity.magnitude == 0f)
		{
			Destroy(this.gameObject);
		}
	}
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().die();
        }
    }
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Ground")
		{
			if((transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).magnitude <= 10)
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}
	
}
