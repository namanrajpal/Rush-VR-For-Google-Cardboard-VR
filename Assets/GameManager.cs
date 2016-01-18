using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject[] cubes;
	public GameObject player;
	public GameObject collect;
	public GameObject collect2;
	public static float spawnTimerLimit;
	public static string state;
	private float spawnTimer;
	private float gameTimer;
	public Animator anim;

	public static float score;

	private Vector3 spawnPos;
	Quaternion rot;
	private Color col1;
	// Use this for initialization
	void Start () {

		spawnPos = new Vector3 (0f, 5f, 40f);
		player = GameObject.FindGameObjectWithTag ("Player");
		col1 = RenderSettings.ambientLight;
		score = 0;
		spawnTimerLimit = 1.8f;
	}
	
	// Update is called once per frame
	void Update () {

		//Checking for the Starting Part
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("startMenu2")||anim.GetCurrentAnimatorStateInfo (0).IsName ("startMenu")) {
						//Debug.Log ("In Startpart");
						if (Cardboard.SDK.Triggered) {
				
								anim.SetTrigger ("inMenu");
				
						}
				} else {
						
						
			//this condition prevents timers in Gameover screen			
			if(!anim.GetCurrentAnimatorStateInfo (0).IsName ("Gameover"))
			{
						score +=  2*Time.deltaTime;
						spawnTimer += Time.deltaTime;
						gameTimer += Time.deltaTime;

			}
				
						//This code is for light changes
						if (gameTimer >= 10f) {
								RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, Color.clear, 1f * Time.deltaTime);
								//RenderSettings.fogColor = Color.Lerp (RenderSettings.ambientLight, Color.red, 2f * Time.deltaTime);
						}
						if (gameTimer >= 20f) {
								RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, Color.gray, 1f * Time.deltaTime);
								//RenderSettings.fogColor = Color.Lerp (RenderSettings.ambientLight, Color.yellow, 2f * Time.deltaTime);			
			
						}
						if (gameTimer >= 30f) {
								RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, Color.cyan, 1f * Time.deltaTime);
								//RenderSettings.fogColor = Color.Lerp (RenderSettings.ambientLight, Color.grey, 2f * Time.deltaTime);
						}
						if (gameTimer >= 40f) {
								RenderSettings.ambientLight = Color.Lerp (RenderSettings.ambientLight, Color.yellow, 1f * Time.deltaTime);
								//RenderSettings.fogColor = Color.Lerp (RenderSettings.ambientLight, Color.cyan, 2f * Time.deltaTime);
						}
						if (gameTimer >= 50f) {
								gameTimer = 0f;		
						}

			//this is the restart code
			if(anim.GetCurrentAnimatorStateInfo (0).IsName ("Gameover"))
			{if (Cardboard.SDK.Triggered) {
				
				spawnTimer=0f;
				Application.LoadLevel (Application.loadedLevel);
				
				}}

				}



			
		//Quaternion camRot = Camera.main.transform.rotation;
		//if (score > 300) {
		//	Camera.main.transform.rotation = new Quaternion(Camera.main.transform.rotation.x,Camera.main.transform.rotation.y,Mathf.Lerp(camRot.z,180f,2f),1f);
					
		//}


	}


	//Spawning Objects here in Late update to prevent objects from getting indsantiated if level is restarted..

	void LateUpdate()
	{
		if (spawnTimer >= spawnTimerLimit) {
						//spawnPos = player.transform.position + spawnPos;
						spawnPos.z = Random.Range (player.transform.position.z + 25f, player.transform.position.z + 35f);
						spawnPos.x = Random.Range (player.transform.position.x - 2f, player.transform.position.x + 2f);
						spawnPos.y = Random.Range (player.transform.position.y + 1f, player.transform.position.y + 2f);

						if ((score > 2500 && score<5200)||(score>11000&&score<14000)) {
				//int index = (int)Random.Range (0, 3);
				rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
				Instantiate (cubes [3], new Vector3 (spawnPos.x, spawnPos.y, spawnPos.z), rot);
				
				//index = (int)Random.Range (0, 2);
				rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
				Instantiate (cubes [3], new Vector3 (spawnPos.x + 5f, spawnPos.y, spawnPos.z + 4f), rot);
				
				//index = (int)Random.Range (0, 2);
				//rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
				//Instantiate (cubes [3], new Vector3 (spawnPos.x - 5f, spawnPos.y, spawnPos.z + 4f), rot);
				
				//index = (int)Random.Range (0, 2);
				rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
				Instantiate (cubes [3], new Vector3 (spawnPos.x + 15f, spawnPos.y, spawnPos.z + 5f), rot);
				
				//index = (int)Random.Range (0, 2);
				//rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
				//Instantiate (cubes [3], new Vector3 (spawnPos.x - 15f, spawnPos.y, spawnPos.z + 5f), rot);
				
				//Spawning Collectibles..Variate if u feel like the game is getting mainstream
				Instantiate (collect, new Vector3 (spawnPos.x, 0.5f, spawnPos.z + 10f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x + 3f, 0.5f, spawnPos.z + 7f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x - 2, 0.5f, spawnPos.z + 9f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x + 2f, 0.5f, spawnPos.z + 5f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x - 1f, 0.5f, spawnPos.z + 11f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x + 1f, 0.5f, spawnPos.z + 7f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x - 3f, 0.5f, spawnPos.z + 11f), Quaternion.identity);
				Instantiate (collect, new Vector3 (spawnPos.x + 4f, 0.5f, spawnPos.z + 7f), Quaternion.identity);

				//Collectibles-2, speciality : power of surviving blows(temporary god mode)
				//Instantiate (collect2, new Vector3 (spawnPos.x - 1f, 0.5f, spawnPos.z + 10f), Quaternion.identity);
				if(Random.Range(0,4)<=1)
				Instantiate (collect2, new Vector3 (spawnPos.x + 1f, 0.5f, spawnPos.z + 13f), Quaternion.identity);

				//Debug.Log("respawn");
				//spawnPos.z+=5f;
				spawnTimer = 0f; //reset SpawnTimer




						} else {
								int index = (int)Random.Range (0, 3);
								rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
								Instantiate (cubes [index], new Vector3 (spawnPos.x, spawnPos.y, spawnPos.z), rot);
			
								index = (int)Random.Range (0, 2);
								rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
								Instantiate (cubes [index], new Vector3 (spawnPos.x + 5f, spawnPos.y, spawnPos.z + 4f), rot);
			
								index = (int)Random.Range (0, 2);
								rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
								Instantiate (cubes [index], new Vector3 (spawnPos.x - 5f, spawnPos.y, spawnPos.z + 4f), rot);
			
								index = (int)Random.Range (0, 2);
								rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
								Instantiate (cubes [index], new Vector3 (spawnPos.x + 15f, spawnPos.y, spawnPos.z + 5f), rot);
			
								index = (int)Random.Range (0, 2);
								rot = new Quaternion (0f, 0f, Random.Range (-1.5f, 1.5f), 8f);
								Instantiate (cubes [index], new Vector3 (spawnPos.x - 15f, spawnPos.y, spawnPos.z + 5f), rot);
			
								//Spawning Collectibles..Variate if u feel like the game is getting mainstream
								Instantiate (collect, new Vector3 (spawnPos.x, 0.5f, spawnPos.z + 10f), Quaternion.identity);
								Instantiate (collect, new Vector3 (spawnPos.x + 3f, 0.5f, spawnPos.z + 7f), Quaternion.identity);
			
								Instantiate (collect, new Vector3 (spawnPos.x - 2, 0.5f, spawnPos.z + 9f), Quaternion.identity);
								Instantiate (collect, new Vector3 (spawnPos.x + 2f, 0.5f, spawnPos.z + 5f), Quaternion.identity);
			
								Instantiate (collect, new Vector3 (spawnPos.x - 1f, 0.5f, spawnPos.z + 11f), Quaternion.identity);
								Instantiate (collect, new Vector3 (spawnPos.x + 1f, 0.5f, spawnPos.z + 7f), Quaternion.identity);
								//Debug.Log("respawn");
								//spawnPos.z+=5f;
								
				//Instantiate (collect2, new Vector3 (spawnPos.x - 1f, 0.5f, spawnPos.z + 10f), Quaternion.identity);
									if(Random.Range(0,4)<=1)
									Instantiate (collect2, new Vector3 (spawnPos.x + 1f, 0.5f, spawnPos.z + 13f), Quaternion.identity);
								
									spawnTimer = 0f; //reseting SpawnTimer for timed instantiation
						}


		}

	}



}
