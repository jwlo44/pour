using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enables a gameobject when winning
public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject enableOnWin;
    [SerializeField]
    private Text flowerCountUI;

    private void OnWin()
    {
        enableOnWin.SetActive(true);
    }

    private void OnFlowerCountChanged(int flowersLeft, int totalFlowers)
    {
        flowerCountUI.text = string.Format("Flowers Fully Grown: {0}/{1}", totalFlowers - flowersLeft, totalFlowers);
    }

	// Use this for initialization
	void Awake () {
        FlowerManager.OnWin += OnWin;
        FlowerManager.OnFlowerGrown += OnFlowerCountChanged;
        FlowerManager.OnFlowerAdded += OnFlowerCountChanged;
	}
	void OnDestroy()
    {
        FlowerManager.OnWin -= OnWin;
        FlowerManager.OnFlowerGrown -= OnFlowerCountChanged;
        FlowerManager.OnFlowerAdded -= OnFlowerCountChanged;
    }
}
