using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class startmenu : MonoBehaviour {
    public Button startButton;
	// Use this for initialization
	void Start () {
        startButton.onClick.AddListener(TaskOnClick);
	}
	void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
