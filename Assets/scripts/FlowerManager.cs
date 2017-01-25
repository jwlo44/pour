using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// FlowerManager counts how many flowers are left
public class FlowerManager : MonoBehaviour {

    private int flowersLeft = 0;
    private int totalFlowers = 0;
    public void IncrementFlowerCount()
    {
        flowersLeft++;
        Debug.Log("Flower added! Total flowers: " + flowersLeft);
    }
    public void IncrementTotalFlowers()
    {
        totalFlowers++;
    }

    public delegate void OnWinEvent();
    public static event OnWinEvent OnWin;

    // for when a flower first becomes fully grown
    public delegate void FlowerGrownEvent(int flowersLeft, int totalFlowers);
    public static event FlowerGrownEvent OnFlowerGrown;

    // handle win fires the win event and does anything else the gm needs to do at that time
    private void HandleWin()
    {
        Debug.Log("WINNER WINNER WINNER!");
        if (OnWin != null)
        {
            OnWin();
        }
    }

    // HandleFlowerGrown is called when the manager sends a flower growth event
    public void HandleFlowerGrown()
    {
        flowersLeft--;
        if (OnFlowerGrown != null)
        {
            OnFlowerGrown(flowersLeft, totalFlowers);
        }
        Debug.Log("Flower grown! Flowers left: " + flowersLeft);
        if (flowersLeft <= 0)
        {
            HandleWin();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
