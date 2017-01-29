using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGUI : MonoBehaviour {
    private Text m_text;
    private float m_time;
    // Use this for initialization
    void Start () {
        m_text = GetComponent<Text>();
        m_time = 0;
    }
	
	// Update is called once per frame
	void Update () {
        m_time += Time.deltaTime;
        m_text.text = "Time Passed : " + m_time.ToString("0.00");
	}
}
