using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    GameObject m_player;
    ScoreManager m_scoreManager;
    GameManager m_gameManager;

    Rigidbody m_rb;

    int m_health = 3;

    public float m_speed = 1;

    bool m_isColliding = false;
    Vector3 m_repelingForce;
    

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.Find("Player");
        m_scoreManager = GameObject.Find("Managers").GetComponent<ScoreManager>();
        m_gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gameManager.GetGameOver() == false)
        {
            Vector3 direction =  m_player.transform.position - transform.position;
            direction = Vector3.Normalize(direction);

            m_rb.velocity = direction * m_speed;

            if(m_isColliding )
            {
                m_rb.AddForce(m_repelingForce, ForceMode.Impulse);
            }
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //damage player
        if(collision.gameObject.tag == "Player")
        {
            m_player.GetComponent<HealthController>().TakeDamage();
        }
        //takeDamage
        if(collision.gameObject.tag == "Projectile")
        {
            m_health--;
            if(m_health <= 0)
            {
                m_scoreManager.IncreaseScore(1);
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "Enemy")
        {
            Vector3 direction = collision.transform.position - transform.position;
            direction = -Vector3.Normalize(direction);
            m_repelingForce = direction;
            m_isColliding = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            m_isColliding = false;
        }
    }




}
