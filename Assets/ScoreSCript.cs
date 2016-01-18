using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreSCript : MonoBehaviour {

	public Animator anim;
	public float speed;
	Text text;
	// Use this for initialization
	void Start () {
		text = GetComponent<Text> ();
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {


		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("startMenu2")||anim.GetCurrentAnimatorStateInfo (0).IsName ("startMenu")) {
			speed = 8f;		
		} else {
			if(anim.GetCurrentAnimatorStateInfo (0).IsName ("Gameover"))
			{}
			else
			speed += Time.deltaTime / 10;
			//		}Debug.Log (speed);
		}
		if (gameObject.tag == "score")
						text.text = "Score: " + (int)GameManager.score;
				else {
						if(gameObject.tag == "highscore")
						text.text = "HighScore: " + (PlayerPrefs.GetInt("highscore",0));
						else
						text.text = "Diamonds: " + (int)BodyCollision.collectedCoins;
				}
		if (gameObject.tag == "coinscollected")
						text.text = "Diamonds : " + PlayerPrefs.GetInt ("coins");

	}
}
