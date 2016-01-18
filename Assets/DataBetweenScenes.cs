using UnityEngine;
using System.Collections;

public class DataBetweenScenes : MonoBehaviour {

	public static bool VRmode;

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {

		VRmode = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setVRmode()
	{
		VRmode = true;
		Application.LoadLevel ("mainPlayscreen");
	}

	public void setNormalmode()
	{
		VRmode = false;
		Application.LoadLevel ("mainPlayscreen");
	}

}
