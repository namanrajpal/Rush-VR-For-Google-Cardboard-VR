using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour {

	Image image;
	bool isCollected;
	Color col;
	public Animator anim;
	//GameObject body;
	// Use this for initialization
	void Start () {
		isCollected = false;
		image = GetComponent<Image> ();
		col = image.color;
		Debug.Log (col);
		//body = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		isCollected = BodyCollision.isCollected;
		if (isCollected == true) {
			Debug.Log("Screen Flashing");
			//do screen green flash here
			anim.SetBool("flashing",true);
			//image.color = Color.Lerp (image.color,Color.green,2f*Time.deltaTime);
			Debug.Log (image.color);
		
				} else {
			anim.SetBool("flashing",false);
			//image.color = col;
		}
	
	}
}
