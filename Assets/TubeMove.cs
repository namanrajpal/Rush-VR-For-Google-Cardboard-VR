using UnityEngine;
using System.Collections;

public class TubeMove : MonoBehaviour {


	float x;
	// Use this for initialization
	void Start () {
	 x = Random.Range (1f, 5f);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	

		rigidbody.AddForce(new Vector3(x,0f,0f),ForceMode.Force);
	}
}
