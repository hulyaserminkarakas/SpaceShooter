using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {          //PlayerScript fonksiyon adı ilkler büyük

	//[HideInInspector]
	public float speed = 50.0f;
	//	public bool isAlive = false;  //bool: true or false
//	public Vector3 targetPosition;        //değişken ismi ilk harfi küçük, ikinci harfi büyük camel case
//  public int lives = 2 ;
	public AudioSource voicer;
	private float verticalBoundry;
	private float horizontalBoundry;
	public GameObject laserPrefab;
	public int ispowerUp = 0;  

 
	void Awake(){


	}
	// Use this for initialization
	void Start () {
		verticalBoundry = Camera.main.orthographicSize;
		horizontalBoundry = verticalBoundry * Camera.main.aspect;

		//Debug.Log ("Vertical Bound: " + verticalBoundry);
	//	Debug.Log ("Horizontal Bound: " + horizontalBoundry);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Input.GetAxis("Horizontal") * speed * Time.deltaTime,
							 Input.GetAxis("Vertical")   * speed * Time.deltaTime,
			                	 0.0f);	

		Vector3 newPosition = new Vector3 (
			Mathf.Clamp (transform.position.x, -horizontalBoundry + 5.0f, horizontalBoundry - 5.0f),
			Mathf.Clamp (transform.position.y, -(verticalBoundry-5.0f)  , verticalBoundry-5.0f),
											  0.0f
										   );

		transform.position = newPosition;

		if (Input.GetKeyDown (KeyCode.Space)) //Bastığı an 
		{                


			Vector3 laserPosition = new Vector3 (transform.position.x,
				                       transform.position.y + 4.5f,
				                       0.0f);

			if (ispowerUp == 0)
				Instantiate (laserPrefab, laserPosition, Quaternion.identity); //identity= .euler(x,y,z);
			else if (ispowerUp == 1) {
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,45.0f));
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,-45.0f));
										}
			else if (ispowerUp == 2) {
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,25.0f));
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,-25.0f));
			}

			else if (ispowerUp > 2) {
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,15.0f));
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,-15.0f));
				Instantiate (laserPrefab, laserPosition, Quaternion.Euler(0.0f,0.0f,0.0f));
			}

			voicer.Play();
		}
	}


	void OnTriggerEnter(Collider other){ //OnCollisionEnter gerçek/fiziksel çarpışma, mesela araba oyununda. Fakat temas var mı durumu farklı; bu çarpışma değildir. Bu trigger

		if(other.gameObject.tag =="Astroid"){
			Destroy (other.gameObject);

			if (!GameObject.Find ("GameController").GetComponent<GameManager> ().DecreaseLife ()) {
				Destroy (gameObject);
				//Application.LoadLevel ("MidLevel");  deplicate code, artık böyle kullanılmıyor, ama şu an çalışacak. Bir süre sonra çalışmayabilir, diğer koda geçiliyor
				SceneManager.LoadScene("MidLevel"); //LoadScene(1);
			}
			else{
				GetComponent<Animator> ().SetBool ("GhostState", true);

				Invoke("CloseGhostAnim",2.0f);
				GetComponent<SphereCollider> ().enabled = false;
				}
		}

		if (other.gameObject.tag == "powerUp") {
			ispowerUp ++;
			Destroy (other.gameObject);
			Invoke("ClosePowerUp",5.0f);
		}
			
}
public void CloseGhostAnim(){
	GetComponent<Animator> ().SetBool ("GhostState", false);
	GetComponent<SphereCollider> ().enabled = true;
}

	public void ClosePowerUp(){
		ispowerUp = 0;

	}

}