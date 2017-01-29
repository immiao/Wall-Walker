using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour {
    private Text m_text;
    private int m_starCounter;
    public int m_total;
	// Use this for initialization
	void Start () {
        m_text = GetComponent<Text>();
        m_starCounter = 0;
	}
	
    public void IncStarCounter()
    {
        m_starCounter++;
        m_text.text = m_starCounter + " / " + m_total;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
