using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidMoment : MonoBehaviour {
	private float minSpeed= -30;
	private float maxSpeed = -80;

	private float minScale= 2;
	private float maxScale= 8;
	private float speed;
	private float scale;

	private float verticalBoundry;



	// Use this for initialization
	void Start () {
		 speed = Random.Range (minSpeed, maxSpeed);
		 scale = Random.Range (minScale, maxScale);	

		transform.localScale = new Vector3 (scale, scale, 1.0f);

		verticalBoundry = Camera.main.orthographicSize;
		}
	
	// Update is called once per frame
	void Update () {


		transform.Translate (0.0f,speed*Time.deltaTime, 0.0f);


		if (transform.position.y <= -verticalBoundry - 5.0f) {

			Destroy (gameObject);
		}



	}
}
