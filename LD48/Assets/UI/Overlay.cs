using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Overlay : MonoBehaviour
{
	
	public static Overlay instance;
	
	[SerializeField] Text deathCounter;
	[SerializeField] Text timerText;
	
	private float timer;
	private bool timerRunning;
	
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
		
		timerRunning = !(SceneManager.GetActiveScene().name == "Level0");
	}
	
	void Update()
	{
		if(timerRunning)
		{
			timer += Time.deltaTime;
			timerText.text = "Time: " + timer.ToString("0");
		}
	}
	
	public void Reset()
	{
		deaths = 0;
		deathCounter.text = "Deaths: " + deaths;
		timer = 0f;
		StartTimer();
	}
	
    public void PlayerDied()
	{
		deaths++;
		deathCounter.text = "Deaths: " + deaths;
	}
	
	public void StartTimer()
	{
		timerRunning = true;
	}
	
	public void StopTimer()
	{
		timerRunning = false;
	}
}
