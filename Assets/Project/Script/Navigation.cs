using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour {

	private GameObject hit;
	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {

	}
	/// <summary>
	/// Handle Navigation from One Station to an other
	/// </summary>
	/// <param name="obj"></param>

	public void NavigateToNewStation(GameObject obj)
	{
		iTween.MoveTo(Camera.main.gameObject, new Vector3(obj.transform.position.x, 1.6f, obj.transform.position.z), 1.0f);
	}
	public void PlayAudio(AudioSource a)
	{
		var A=GameObject.FindObjectsOfType<AudioSource>();
		foreach(var x in A)
		{
			x.Stop();
		}
		if(a!=null)
			a.PlayDelayed(1);
		
	}

	private void BuildStationImageGallary()
	{

	}

	public void HideUI(GameObject o)
	{
		o.SetActive(false);
	}
	public void RestartGame()
	{
		SceneManager.LoadScene(0);
	}
}
