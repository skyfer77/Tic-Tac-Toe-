using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Active : MonoBehaviour {
	public GameObject panel;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("Difficult") == "Human") {
			panel.SetActive (false);
		}
		else 
			panel.SetActive (true);
	}
	

}
