using UnityEngine;
using System.Collections;

public class FrontSpawner : MonoBehaviour {


	public GameObject ground;
	Vector3 spawnpos;

	// Use this for initialization
	void Start () {
		spawnpos = new Vector3 (0f, 0f, 60f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
						
						if (other.gameObject.tag == "spawner") {
						Instantiate (ground, transform.position + spawnpos, Quaternion.identity);

						Destroy (gameObject);
				}	
	}
}
