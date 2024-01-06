using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    Rigidbody rb;

    public float m_speed = 10;
    public float m_maxSpeed = 10;
    float m_minSpeed = 0;

    bool m_forward, m_backward, m_left, m_right;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        m_forward = Input.GetKey(KeyCode.W);
        m_backward = Input.GetKey(KeyCode.S);
        m_left = Input.GetKey(KeyCode.A);
        m_right = Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
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
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject collectable = collision.transform.gameObject;

        collectable.GetComponent<Pickup>().GetPickedUp();
    }
}
