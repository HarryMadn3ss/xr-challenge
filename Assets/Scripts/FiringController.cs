using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringController : MonoBehaviour
{
    bool m_isFiring;
    float m_cooldown;
    public float m_maxCooldown = 1;

    public float m_speed = 10;

    bool m_fireUp, m_fireDown, m_fireLeft, m_fireRight;

    public GameObject m_projectile;
    Vector3 m_projectileVelocity = Vector3.zero;
    Vector3 m_spwanPos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_isFiring = false;
        m_cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_cooldown -= Time.deltaTime;

        m_fireUp = Input.GetKey(KeyCode.UpArrow);
        m_fireRight = Input.GetKey(KeyCode.RightArrow);
        m_fireDown = Input.GetKey(KeyCode.DownArrow);
        m_fireLeft = Input.GetKey(KeyCode.LeftArrow);
        

        if (m_fireUp || m_fireRight || m_fireDown || m_fireLeft)
        {
            m_isFiring = true;
        }
        else
        {
            m_isFiring = false;
        }

        if (m_isFiring && m_cooldown <= 0)
        {
            if (m_fireUp)
            {
                m_projectileVelocity.z = 1;
                m_spwanPos.z = transform.position.z + 0.8f;
            }
            else if (m_fireDown)
            {
                m_projectileVelocity.z = -1;
                m_spwanPos.z = transform.position.z - 0.8f;
            }
            else if (m_fireLeft)
            {
                m_projectileVelocity.x = -2.1f;
                m_spwanPos.x = transform.position.x - 0.8f;
            }
            else if (m_fireRight)
            {
                m_projectileVelocity.x = 1;
                m_spwanPos.x = transform.position.x + 0.8f;
            }

            m_projectileVelocity *= m_speed;
            Instantiate(m_projectile, m_spwanPos, Quaternion.identity);

            m_cooldown = m_maxCooldown;
        }
            m_spwanPos = transform.position;

    }

    public Vector3 GetProjectileVelocity() { return m_projectileVelocity; }

    public void ResetVelocity(){ m_projectileVelocity = Vector3.zero; }

}
