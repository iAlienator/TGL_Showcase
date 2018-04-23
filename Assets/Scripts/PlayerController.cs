using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetAxis("Horizontal") != 0)
            transform.position += new Vector3(Input.GetAxis("Horizontal"), 0);
        if (Input.GetAxis("Vertical") != 0)
            transform.position += new Vector3(0, Input.GetAxis("Vertical"));
    }
    
    public void Move(Vector2 direction)
    {

    }
}
