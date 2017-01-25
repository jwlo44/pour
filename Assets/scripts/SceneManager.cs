using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enables a gameobject when winning
public class SceneManager : MonoBehaviour {

    [SerializeField]
    private GameObject enableOnWin;

    private void OnWin()
    {
        enableOnWin.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        FlowerManager.OnWin += OnWin;
	}
	void OnDestroy()
    {
        FlowerManager.OnWin -= OnWin;
    }
}
