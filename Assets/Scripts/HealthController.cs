using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class HealthController : MonoBehaviour
{
    public float m_health;
    public float m_damageValue = 20;
    float m_iFrames = 0;
    float m_maxHealth = 100;

    GameManager m_gameManager;
    Rigidbody m_rb;

    UnityEngine.UI.Image m_healthBar;

    // Start is called before the first frame update
    void Start()
    {
        m_health = m_maxHealth;
        m_gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        m_rb = GetComponent<Rigidbody>();
        m_healthBar = GameObject.Find("HealthBarInner").GetComponent<UnityEngine.UI.Image>();
    }

    // Update is called once per frame
    void Update()
    {
        m_iFrames -= Time.deltaTime;
        m_healthBar.fillAmount = m_health / 100;        
    }

    public void TakeDamage()
    {
        if(m_iFrames <= 0)
        {
            m_health -= m_damageValue;       

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
