using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    public float m_speed = 10;

    Rigidbody m_RB;
    Camera m_Camera;

   

    // Start is called before the first frame update
    void Start()
    {
        m_RB = GetComponent<Rigidbody>();
        m_Camera = GameObject.Find("Camera").GetComponent<Camera>();

        m_Camera.

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mousePos.y;
        mousePos.y = 1;
        Vector3 firingDirection = m_Camera.ScreenToWorldPoint(mousePos);        
        firingDirection = firingDirection - GameObject.Find("Player").GetComponent<Transform>().position;
        firingDirection = firingDirection.normalized;

        m_RB.velocity = firingDirection;
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Projectile")
        //{

        //}
        //else
        //{
        //    Destroy(this.gameObject);
        //}
    }
}
