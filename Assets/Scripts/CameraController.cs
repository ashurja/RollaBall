using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
		// The code above is used to keep the distance between the camera and the ball constant. 
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset; 
	}
}
