using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	public GameObject[] astroids;
	private float horizontalBoundry;
	private float verticalBoundry;
	private Vector3 astroidPosition;
	private int score=0;
	private int extraLife=3;
	// Use this for initialization
	void Start () {
		verticalBoundry = Camera.main.orthographicSize;
		horizontalBoundry = verticalBoundry * Camera.main.aspect;
		PlayerPrefs.DeleteKey ("score"); 
		InvokeRepeating ("InstantiateAstroids", 0.0f, 1.4f);  //1.si fonksiyonun adı, 2.si başlama süresi, 3.sü sıklığı


			
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}

	void InstantiateAstroids(){
	

		astroidPosition = new Vector3 ( Random.Range (-horizontalBoundry+5.0f, horizontalBoundry -5.0f), 
												verticalBoundry + 5.0f,
												0.0f);
				Instantiate (astroids [Random.Range (0, astroids.Length)], astroidPosition, Quaternion.identity); //belirli bir aralık içinde oluştur	

	
	}


	public void AddScore(int score){

		this.score += score; // this den sonraki score en yukarıdaki score, atamadan sonraki score görebildiğin ilk score

		PlayerPrefs.SetInt("score",this.score);
	}


	public bool DecreaseLife (){

		extraLife--;

		if (extraLife == 0)
			return false;

		return true;
	}

	void OnGUI(){
		GUI.Label (new Rect(10,10,100,25), "Score :" + score); //35. pikselde bitti, diğeri 40 dan başlasın
		GUI.Label (new Rect(10,40,100,25), "Extra Life :" + extraLife);
	}



}
