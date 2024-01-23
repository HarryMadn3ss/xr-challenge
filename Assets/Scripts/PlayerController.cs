using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    Rigidbody m_rb;

    float m_speed = 250;
    float m_maxSpeed = 50;
    float m_minSpeed = 0;
    float m_defaultSpeed = 250;
    float m_sprintSpeed = 1000;

    bool m_forward, m_backward, m_left, m_right, m_sprinting;    

    GameManager m_manager;
    public GameObject m_projectile;
    

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_manager = GameObject.Find("Managers").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_forward = Input.GetKey(KeyCode.W);
        m_backward = Input.GetKey(KeyCode.S);
        m_left = Input.GetKey(KeyCode.A);
        m_right = Input.GetKey(KeyCode.D);
        m_sprinting = Input.GetKey(KeyCode.LeftShift);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_manager.ResetScene();
        }
    }

    private void FixedUpdate()
    {
        //movement
        if(m_sprinting)
        {
            m_speed = m_sprintSpeed;
        }
        else if(!m_sprinting)
        {
            m_speed = m_defaultSpeed;
        }

        if(m_forward && m_right)
        {
            m_rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        } 
        else if(m_backward && m_right)
        {
            m_rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        else if(m_backward && m_left)
        {
            m_rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        else if (m_forward && m_left)
        {
            m_rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0, Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        } 
        else if(m_forward)
        {
            m_rb.velocity = new Vector3(0, 0, Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        else if(m_backward)
        {
            m_rb.velocity = new Vector3(0, 0, -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        else if(m_left)
        {
            m_rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0, 0);
        }
        else if(m_right)
        {
            m_rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0, 0);
        }
        else
        {
            m_rb.velocity = Vector3.zero;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Star")
        {
            GameObject collectable = collision.transform.gameObject;

            collectable.GetComponent<Pickup>().GetPickedUp();

            m_manager.GetComponent<ScoreManager>().IncreaseScore(collectable.GetComponent<Pickup>().ScoreValue);

            Destroy(collectable);
        }        
    }
}
