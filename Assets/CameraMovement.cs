using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+speed*Time.deltaTime);
	
	}
}
