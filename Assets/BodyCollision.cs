using UnityEngine;
using System.Collections;

public class BodyCollision : MonoBehaviour {

	// Use this for initialization
	public float duration;
	public float magnitude;
	ParticleSystem particles;
	public Animator anim;
	private bool isGameOver;
	public static bool isCollected;
	private float flipTimer;
	public static int collectedCoins;

	void Start () {
		particles = GetComponent<ParticleSystem> ();
		isGameOver = false;
		isCollected = false;
		collectedCoins = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (isCollected == true) {
		
			flipTimer+=Time.deltaTime;
			if(flipTimer>=4f)
			{
				isCollected=false;
				flipTimer=0f;
			}

		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "collectible") {


			particles.Emit(1000);
//			Debug.Log("Collected");
			Destroy(other.gameObject);
			GameManager.score+=200;
			collectedCoins++;

				} else {
			if(other.gameObject.tag == "collectible2")
			{
				GameManager.score+=1500;
				isCollected =true;
			}else{
				if(isCollected == false)
				isGameOver =true;
			}

						
			}

		if (isGameOver == true && isCollected==false) {
			//game Over Code
			Debug.Log(other.gameObject.ToString());
			Destroy(other.gameObject);
			Debug.Log ("GameOver");
			Debug.Log ((int)GameManager.score);
			if(((int)GameManager.score)>PlayerPrefs.GetInt("highscore",0))
			{
				PlayerPrefs.SetInt("highscore",(int)GameManager.score);
			}
			Debug.Log(collectedCoins);
			PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins",0)+collectedCoins);
			StartCoroutine (Shake ());
			anim.SetTrigger("gameOver");		
		}
	}

	IEnumerator Shake() {
		
		float elapsed = 0.0f;
		
		Vector3 originalCamPos = Camera.main.transform.position;
		Vector3 originalPlayerPos = gameObject.GetComponentInParent<Transform>().position;
		
		while (elapsed < duration) {
			
			elapsed += Time.deltaTime;          
			
			float percentComplete = elapsed / duration;         
			float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);
			
			// map value to [-1, 1]
			float x = Random.value * 2.0f - 1.0f;
			float z = Random.value * 2.0f - 1.0f;
			x *= magnitude * damper;
			z *= magnitude * damper;
			
			Camera.main.transform.position = new Vector3(x, originalCamPos.y, originalCamPos.z);
			
			yield return null;
		}
		
		Camera.main.transform.position = originalCamPos;

	}
}
