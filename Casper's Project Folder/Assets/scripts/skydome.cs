using UnityEngine;
using System.Collections;

public class skydome : MonoBehaviour {

    int rotateSpeed;

	// Use this for initialization
	void Start () {
        rotateSpeed = 3; //Sets the rotation speed
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * Time.deltaTime*rotateSpeed); //Rotates the skydome with time
	}
}
