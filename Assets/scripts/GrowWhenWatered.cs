using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWhenWatered : MonoBehaviour {

    bool grow = false;
    public Vector3 growthRate = new Vector3(0, .1f, 0);
    public Vector3 maxGrowthScale = new Vector3(1, 1, 1);
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // grows the localscale of the transform while colliding with the watering can until reaching max growth
		if (grow)
        {
            if (gameObject.transform.localScale.x < maxGrowthScale.x)
            {
                gameObject.transform.localScale += new Vector3(growthRate.x, 0);
            }
            if (gameObject.transform.localScale.y < maxGrowthScale.y)
            {
                gameObject.transform.localScale += new Vector3(0, growthRate.y);
            }
            if (gameObject.transform.localScale.z < maxGrowthScale.z)
            {
                gameObject.transform.localScale += new Vector3(0,0,growthRate.z);
            }
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
