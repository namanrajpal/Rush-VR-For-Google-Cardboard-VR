using UnityEngine;
using System.Collections;

public class CubeRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (new Vector3 (0f, 5f, 0f));
	}

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.gameObject.ToString ());
		if ((other.gameObject.ToString() == "bodyTrigger")==false) {
			if((other.gameObject.ToString() == "SpawnTrigger")==false)
			{}else
			Destroy(gameObject);
		
		
		}
	}
}
