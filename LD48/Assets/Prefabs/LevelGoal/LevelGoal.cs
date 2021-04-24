using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    
	[SerializeField] string nextLevelName;
	
	private bool reached = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!reached && collision.gameObject.tag == "Player")
        {
            reached = true;
			StartCoroutine(StartNextLevel());
        }
    }
	
	private IEnumerator StartNextLevel()
	{
		
		yield return new WaitForSeconds(0.5f);
		
		GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(0, 0, 1);
		
		yield return new WaitForSeconds(1.5f);
		
		SceneManager.LoadScene(nextLevelName);
	}
	
}
