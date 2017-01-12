using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiggleDance : MonoBehaviour {
    [Tooltip("the max amount this object will rotate by")]
    public float wiggleAmount = 30f;
    [Tooltip("the speed at which we wiggle")]
    public float wiggleRate = 3;
    public Vector3 rotateAround = new Vector3(0,0,1);

    float amount = 0;
    float direction = 1;

    void Start()
    {
        gameObject.transform.Rotate(rotateAround, -wiggleAmount);
    }

	// Update is called once per frame
	void Update () {
        if (amount > wiggleAmount * 2)
        {
            amount = amount % wiggleAmount;
            direction = -direction;
        }
        amount += wiggleRate;

        this.gameObject.transform.Rotate(rotateAround, wiggleRate * direction);
	}
}
