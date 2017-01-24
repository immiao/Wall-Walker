using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private SceneParent m_playerScript;
    private Rigidbody m_rigidBody;
    private bool m_isSucceeded;
    // Use this for initialization
    void Start () {
        m_rigidBody = GetComponent<Rigidbody>();
        m_isSucceeded = false;
    }
	
	// Update is called once per frame
	void Update () {

        int ws = 0;
        int ad = 0;
        if (Input.GetKey(KeyCode.W))
            ws--;
        if (Input.GetKey(KeyCode.S))
            ws++;
        if (Input.GetKey(KeyCode.A))
            ad--;
        if (Input.GetKey(KeyCode.D))
            ad++;

        if (ws != 0 || ad != 0)
            m_rigidBody.velocity = new Vector3(ws * 3, 0, ad * 3);
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("door"))
            m_isSucceeded = true;
    }


    void OnGUI()
    {
        if (m_isSucceeded)
        {
            GUI.skin.label.fontSize = 20;
            GUI.skin.label.normal.textColor = new Color(0, 0, 0, 1);
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            //GUIStyle background = new GUIStyle();
            //background.normal.background = img;
            //GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", background);

            //int num = 8;

            GUI.Label(new Rect(0, Screen.height / 2, Screen.width, 25), "CONGRATULATION!");
            Time.timeScale = 0.0f;
        }
        
    }
}
