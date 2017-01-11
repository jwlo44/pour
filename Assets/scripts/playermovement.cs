using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playermovement : MonoBehaviour {

    Vector2 walkDirection = Vector2.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.W))
        {
            walkDirection.y = 1.0f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            walkDirection.x = -1.0f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            walkDirection.y = -1.0f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            walkDirection.x = 1.0f;
        }
    }
}
