using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float m_speed = 10;
    public float m_maxSpeed = 10;
    float m_minSpeed = 0;

    bool m_forward, m_backward, m_left, m_right;
    bool m_isFiring;
    float m_fireCooldown = 2;

    GameManager m_manager;
    public GameObject m_projectile;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_forward = Input.GetKey(KeyCode.W);
        m_backward = Input.GetKey(KeyCode.S);
        m_left = Input.GetKey(KeyCode.A);
        m_right = Input.GetKey(KeyCode.D);
        m_isFiring = Input.GetMouseButton(0);
    }

    private void FixedUpdate()
    {
        //movement
        if(m_forward)
        {
            rb.velocity = new Vector3(0, 0, Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        if(m_backward)
        {
            rb.velocity = new Vector3(0, 0, -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        if(m_left)
        {
            rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0, 0);
        }
        if(m_right)
        {
            rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0, 0);
        }

        if(m_forward && m_right)
        {
            rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        } 
        if(m_backward && m_right)
        {
            rb.velocity = new Vector3(Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        if(m_backward && m_left)
        {
            rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , -Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        if(m_forward && m_left)
        {
            rb.velocity = new Vector3(-Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed), 0 , Mathf.Clamp(m_speed * Time.deltaTime, m_minSpeed, m_maxSpeed));
        }
        
        //shooting
        if(m_isFiring && m_fireCooldown <= 0)
        {            
            Instantiate(m_projectile, this.transform.position, Quaternion.identity);
            m_fireCooldown = 2;
        }
        m_fireCooldown -= Time.deltaTime;
        

    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collectable = collision.transform.gameObject;

        collectable.GetComponent<Pickup>().GetPickedUp();

        m_manager.GetComponent<ScoreManager>().IncreaseScore(collectable.GetComponent<Pickup>().ScoreValue);

    }
}
