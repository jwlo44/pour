using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enables a gameobject when winning
public class SceneManager : MonoBehaviour {

    [SerializeField]
    private GameObject enableOnWin;
    [SerializeField]
    private Text flowerCountUI;

    private void OnWin()
    {
        enableOnWin.SetActive(true);
    }

    private void OnFlowerGrown(int flowersLeft, int totalFlowers)
    {
        flowerCountUI.text = string.Format("Flowers Fully Grown: {0}/{1}", totalFlowers - flowersLeft, totalFlowers);
    }

	// Use this for initialization
	void Start () {
        FlowerManager.OnWin += OnWin;
        FlowerManager.OnFlowerGrown += OnFlowerGrown;
	}
	void OnDestroy()
    {
        FlowerManager.OnWin -= OnWin;
        FlowerManager.OnFlowerGrown -= OnFlowerGrown;
    }
}
