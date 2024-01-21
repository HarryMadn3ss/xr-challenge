using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public float m_health;
    float m_iFrames = 0;

    GameManager m_gameManager;
    Rigidbody m_rb;

    // Start is called before the first frame update
    void Start()
    {
        m_health = 1;
        m_gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_iFrames -= Time.deltaTime;
    }

    public void TakeDamage()
    {
        if(m_iFrames <= 0)
        {
            m_health--;
            m_iFrames = 1;
            if (m_health <= 0 )
            {
                m_rb.freezeRotation = false;
                //dead
                m_gameManager.SetGameOver();
            }
        }        
    }
}
