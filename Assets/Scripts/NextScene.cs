using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			GameObject.Find("Canvas").GetComponent<Menu>().winMenuUI.SetActive(true);
			GameObject.Find("Canvas").GetComponent<Menu>().backGround.SetActive(true);
		}
	}
}
