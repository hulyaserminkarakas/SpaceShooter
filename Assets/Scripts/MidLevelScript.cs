using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MidLevelScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){

		GUI.Label (new Rect ((Camera.main.pixelWidth-85) /2, (Camera.main.pixelHeight-60) /2, 85, 25), "Game Over =) ");
		GUI.Label (new Rect ((Camera.main.pixelWidth-100) /2, (Camera.main.pixelHeight /2)+5, 100, 25), "Your score is: " + PlayerPrefs.GetInt("score"));


		if (GUI.Button (new Rect ((Camera.main.pixelWidth - 100) / 2, (Camera.main.pixelHeight / 2) + 40, 100, 25), "Replay")) {

			SceneManager.LoadScene ("_workplace");

		}


	}

}
