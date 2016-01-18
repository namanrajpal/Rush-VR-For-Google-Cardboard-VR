using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float speed;
	public Animator anim;
	// Use this for initialization


	void Awake()
	{
		Cardboard.SDK.VRModeEnabled = DataBetweenScenes.VRmode;
		}
	void Start () {
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
				transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);

		if (anim.GetCurrentAnimatorStateInfo(0).IsName("startMenu2")) {
						speed = 8f;		
				} else {
					
					if(anim.GetCurrentAnimatorStateInfo(0).IsName("startMenu")||anim.GetCurrentAnimatorStateInfo(0).IsName("Gameover"))
					{
						speed=0f;
					}else{
				
						speed += Time.deltaTime / 10;
					}		//		}Debug.Log (speed);
				}

		if (speed > 125&&speed<160) {
		
			GameManager.spawnTimerLimit = 1.4f;
		}
		if(speed>160)GameManager.spawnTimerLimit = 1.2f;

		if (BodyCollision.isCollected == true) {
		//speed up
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
		
		}

		}




}
