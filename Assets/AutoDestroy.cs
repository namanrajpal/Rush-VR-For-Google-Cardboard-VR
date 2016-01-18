using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	public float destroyTimer;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {

				if ((player.transform.position.z - transform.position.z) >= 25f) {
						DestroyImmediate(gameObject);		
				} else {
						Destroy (gameObject, destroyTimer);
				}
		}

}
