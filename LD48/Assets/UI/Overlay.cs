using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : MonoBehaviour
{
	
	public static Overlay instance;
	
	[SerializeField] GameObject	deathCounter;
	
	private int deaths = 0;
	
	void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
			return;
		}
		
		DontDestroyOnLoad(gameObject);
	}
	
	public void Reset()
	{
		deaths = 0;
		deathCounter.GetComponent<UnityEngine.UI.Text>().text = "Deaths: " + deaths;
	}
	
    public void PlayerDied()
	{
		deaths++;
		deathCounter.GetComponent<UnityEngine.UI.Text>().text = "Deaths: " + deaths;
	}
}
