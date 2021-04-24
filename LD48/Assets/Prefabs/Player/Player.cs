using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	[SerializeField] private LayerMask groundMask;
	
	private enum State {IDLE, WALKING};
	
	private float speed = 7f;
	private float jumpForce = 8f;
	private Rigidbody2D rb;
	private Animator anim;
	
	public void die()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		
		DoControls();
        
    }
	
	private void DoControls()
	{
		if(Input.GetKeyDown(KeyCode.Space) && OnGround())
		{//jump
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		
		
		float velX = 0;
		if(Input.GetKey(KeyCode.D))//moving right
		{
			velX += speed;
		}
		else if(Input.GetKey(KeyCode.A))//moving left
		{
			velX -= speed;
		}
		
		rb.velocity = new Vector2(velX, rb.velocity.y);
		UpdateVisuals(velX);
		
	}
	
	private void UpdateVisuals(float velX)
	{
		if(velX < 0)
		{//face left
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		else if(velX > 0)
		{//face right
			transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		
		if(Mathf.Abs(velX) > 0)
		{
			anim.SetInteger("state", (int)State.WALKING);
		}
		else
		{
			anim.SetInteger("state", (int)State.IDLE);
		}
	}
	
	private bool OnGround()
	{
		return Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.6f, groundMask).collider != null;
	}
	
}
