using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowWhenWatered : MonoBehaviour {

    bool grow = false;
    public Vector3 growthRate = new Vector3(0, .1f, 0);
    public Vector3 maxGrowthScale = new Vector3(1, 1, 1);
    // turn this on when fully grown
    [SerializeField]
    private ParticleSystem particleParty;

    [SerializeField]
    private FlowerManager gm;

    void Start()
    {
        gm.IncrementTotalFlowers();
        if (!isFullyGrown())
        {
            gm.IncrementFlowerCount();
        }
    }
	
	// Update is called once per frame
	void Update () {
        // grows the localscale of the transform while colliding with the watering can until reaching max growth
		if (grow && !isFullyGrown())
        {
            int maxScales = 0;
            if (gameObject.transform.localScale.x < maxGrowthScale.x)
            {
                gameObject.transform.localScale += new Vector3(growthRate.x, 0);
            }
            else
            {
                maxScales += 1;
            }
            if (gameObject.transform.localScale.y < maxGrowthScale.y)
            {
                gameObject.transform.localScale += new Vector3(0, growthRate.y);
            }
            else
            {
                maxScales += 1;
            }
            if (gameObject.transform.localScale.z < maxGrowthScale.z)
            {
                gameObject.transform.localScale += new Vector3(0,0,growthRate.z);
            }
            // check if we're fully grown; this should only be executed once.
            if (isFullyGrown())
            {
                OnFullyGrown();
            }
        }
	}
    
    // is the flower at its max growth?
    private bool isFullyGrown()
    {
        return gameObject.transform.localScale.x >= maxGrowthScale.x
            && gameObject.transform.localScale.y >= maxGrowthScale.y
            && gameObject.transform.localScale.z >= maxGrowthScale.z;
    }

    // called when the flower first reaches its max growth
    private void OnFullyGrown()
    {
        particleParty.gameObject.SetActive(true);
        gm.HandleFlowerGrown();
    }
    // detects collision with the watering can water
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wateringCan")
        {
            grow = true;
        }
    }

    // disables growing when watering can leaves the collider
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "wateringCan")
        {
            grow = false;
        }
    }
}
