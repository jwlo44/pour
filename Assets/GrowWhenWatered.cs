using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWhenWatered : MonoBehaviour {

    bool grow = false;
    public Vector3 growthRate = new Vector3(0, .1f, 0);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (grow)
        {
            gameObject.transform.localScale += growthRate;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wateringCan")
        {
            grow = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "wateringCan")
        {
            grow = false;
        }
    }
}
