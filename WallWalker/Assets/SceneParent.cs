using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneParent : MonoBehaviour {

    public Transform[] state = new Transform[3];

    private bool m_isRotating;
    private float m_rotatingTime;
    private int m_fromStateIndex;
    private int m_toStateIndex;
    private Player m_player;

	// Use this for initialization
	void Start () {
        m_isRotating = false;
        m_rotatingTime = 0.0f;
        m_fromStateIndex = m_toStateIndex = 0;
        m_player = GameObject.Find("Sphere").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_isRotating = true;
            m_fromStateIndex = m_toStateIndex;
            m_toStateIndex = (m_toStateIndex + 1) % 3;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_isRotating = true;
            m_fromStateIndex = m_toStateIndex;
            m_toStateIndex = (m_toStateIndex + 2) % 3;
        }

        if (m_isRotating)
        {
            m_player.UseGravity(false);
            m_rotatingTime += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(state[m_fromStateIndex].rotation, state[m_toStateIndex].rotation, m_rotatingTime);
            if (m_rotatingTime > 1.0f)
            {
                m_rotatingTime = 0.0f;
                m_isRotating = false;
                m_player.UseGravity(true);
            }
        }
    }

    public int GetCurrentStateIndex()
    {
        return m_toStateIndex;
    }
}
