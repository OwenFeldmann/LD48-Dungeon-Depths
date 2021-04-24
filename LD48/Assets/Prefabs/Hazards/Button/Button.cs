using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	[SerializeField] private Boulder boulder;
	[SerializeField] private float spawnHeight = 8;
	
	public bool pressed = false;
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!pressed && collision.gameObject.tag == "Player")
        {
            StartCoroutine(Press());
        }
    }

    private IEnumerator Press()
	{
		pressed = true;
		GetComponent<Animator>().SetBool("pressed", pressed);
		Debug.Log(Instantiate(boulder, new Vector3(transform.position.x, transform.position.y + spawnHeight, transform.position.z), Quaternion.identity));
		
		yield return new WaitForSeconds(5f);
		
		pressed = false;
		GetComponent<Animator>().SetBool("pressed", pressed);
	}
}
