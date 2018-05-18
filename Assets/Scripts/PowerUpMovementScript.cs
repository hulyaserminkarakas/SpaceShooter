using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovementScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f,-30.0f*Time.deltaTime, 0.0f);
	}
}
