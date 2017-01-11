using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class WaterOnSpace : MonoBehaviour {

    public GameObject water;

	// Use this for initialization
	void Start () {
        water.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (CrossPlatformInputManager.GetButtonDown("Action"))
        {
            water.SetActive(true);
        }
        if (CrossPlatformInputManager.GetButtonUp("Action"))
        {
            water.SetActive(false);
        }
	}
}
