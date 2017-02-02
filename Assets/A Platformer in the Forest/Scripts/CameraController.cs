using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //  called after all Update functions have been called
    void LateUpdate()
    {
        // set the camera (x,y) to player (x,y), move z back for projection
        transform.position = player.transform.position + Vector3.back;
    }
}
