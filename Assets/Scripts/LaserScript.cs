using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

	public float speed = 80.0f;
	private float verticalBoundry;
	public GameObject powerUp;

	// Use this for initialization
	void Start () {
		verticalBoundry = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0.0f, speed * Time.deltaTime, 0.0f);

		if (transform.position.y > verticalBoundry+3.0f) {

			Destroy (gameObject);
		}
	}


	void OnTriggerEnter(Collider other){

		if(other.gameObject.tag =="Astroid"){
			Destroy (other.gameObject);
			Destroy (gameObject);
			int random = Random.Range (0, 100);
			if (random < 100 && random > 0) {

				Instantiate (powerUp, other.transform.position, Quaternion.identity); // other.transform.position yeterli
			}



			GameObject.Find ("GameController").GetComponent<GameManager> ().AddScore (1);
			//GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ().AddScore (1);
			//GameObject.FindObjectOfType<GameManager> ();
		}

}
}