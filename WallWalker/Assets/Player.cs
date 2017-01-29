using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private SceneParent m_playerScript;
    private Rigidbody m_rigidBody;
    private bool m_isSucceeded;
    private bool m_isFailed;
    private Transform m_cameraPos;
    private Vector3 m_axis;
    private StarText m_starText;
    public int m_nextLevel;

    // Use this for initialization
    void Start() {
        m_starText = GameObject.Find("StarTextObject").GetComponent<StarText>();
        m_cameraPos = GameObject.Find("Main Camera").GetComponent<Transform>();
        m_rigidBody = GetComponent<Rigidbody>();
        m_isSucceeded = false;
        m_isFailed = false;
        m_axis = new Vector3(1, 1, 1) * 10;
        Time.timeScale = 1.0f;
    }
    public void UseGravity(bool b)
    {
        m_rigidBody.useGravity = b;
    }
    // Update is called once per frame
    void Update() {
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
        {
            float vy = m_rigidBody.velocity.y;
            m_rigidBody.velocity = new Vector3(ws * 3, vy, ad * 3);
        }
        if (transform.position.y < -50) m_isFailed = true;
        m_cameraPos.position = transform.position + m_axis;
    }

    void OnCollisionEnter(Collision collision)
    {
        Collider collider = collision.collider;
        if (collider.CompareTag("door"))
            m_isSucceeded = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("star"))
        {
            m_starText.IncStarCounter();
            other.gameObject.SetActive(false);
        }
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

            GUI.Label(new Rect(0, Screen.height / 2 - 100, Screen.width, 25), "CONGRATULATION!");
            Time.timeScale = 0.0f;
            if (GUI.Button(new Rect(Screen.width / 2 - 100, 3 * Screen.height / 7, Screen.width / 4, 60), "Next Level"))
            {
                if (m_nextLevel != -1)
                    SceneManager.LoadScene(m_nextLevel);
            }
        }
        else if (m_isFailed)
        {
            GUI.skin.label.fontSize = 20;
            GUI.skin.label.normal.textColor = new Color(0, 0, 0, 1);
            GUI.skin.label.alignment = TextAnchor.MiddleCenter;
            //GUIStyle background = new GUIStyle();
            //background.normal.background = img;
            //GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", background);

            //int num = 8;

            GUI.Label(new Rect(0, Screen.height / 2, Screen.width, 25), "Game Failed!");
            Time.timeScale = 0.0f;
        }
    }
}
