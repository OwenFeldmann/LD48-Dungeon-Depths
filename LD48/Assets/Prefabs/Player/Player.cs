using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
	
	[SerializeField] LayerMask groundMask;
	
	private enum State {IDLE, WALKING, INAIR};
	
	private float speed = 7f;
	private float jumpForce = 8f;
	private float initialGravityScale;
	private Rigidbody2D rb;
	private Animator anim;
	
	private bool dead = false;
	
	public void die()
	{
		if(!dead)
		{
			StartCoroutine(Die());
		}
	}
	
	private IEnumerator Die()
	{
		dead = true;
		GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(0, 0, 1);
		GetComponent<AudioSource>().Play();
		GameObject.Find("Overlay").GetComponent<Overlay>().PlayerDied();
		
		yield return new WaitForSeconds(0.75f);
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		initialGravityScale = rb.gravityScale;
		anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
		
		DoControls();
        
		if(transform.position.y <= -300)
		{//Too deep, time to restart
			GameObject.Find("Overlay").GetComponent<Overlay>().StopTimer();
			SceneManager.LoadScene("Level0");
		}
		
    }
	
	private void DoControls()
	{
		bool onGround = OnGround();
		
		if(Input.GetKeyDown(KeyCode.Space) && onGround)
		{//jump
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		
		if(!onGround && Input.GetKey(KeyCode.S))
		{//fast fall
			rb.gravityScale = 3f;
		}
		else
		{
			rb.gravityScale = initialGravityScale;
		}
		
		float velX = 0;
		if(Input.GetKey(KeyCode.D))
		{//moving right
			velX += speed;
		}
		else if(Input.GetKey(KeyCode.A))
		{//moving left
			velX -= speed;
		}
		
		rb.velocity = new Vector2(velX, rb.velocity.y);
		UpdateVisuals(velX, onGround);
		
	}
	
	private void UpdateVisuals(float velX, bool onGround)
	{
		if(velX < 0)
		{//face left
			transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		else if(velX > 0)
		{//face right
			transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
		}
		
		if(!onGround)
		{
			anim.SetInteger("state", (int)State.INAIR);
		}
		else
		{
			if(Mathf.Abs(velX) > 0)
			{
				anim.SetInteger("state", (int)State.WALKING);
			}
			else
			{
				anim.SetInteger("state", (int)State.IDLE);
			}
		}
	}
	
	private bool OnGround()
	{
		return Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.6f, groundMask).collider != null;
	}
	
}
