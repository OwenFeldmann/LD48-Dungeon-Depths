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
        // When player collides with trigger, they take damage, and projectile disappears
        if(collision.gameObject.tag == "Player")
        {
            //TODO kill player
			Debug.Log("Boulder hit player");
        }
    }
}
