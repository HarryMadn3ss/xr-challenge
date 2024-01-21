using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Projectile : MonoBehaviour
{
    
    Rigidbody m_RB;
    //Camera m_Camera;

    GameObject m_player;
   

    // Start is called before the first frame update
    void Start()
    {
        //m_RB = GetComponent<Rigidbody>();
        //m_Camera = GameObject.Find("Camera").GetComponent<Camera>();
       

        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = mousePos.y;
        //mousePos.y = 1;
        //Vector3 firingDirection = m_Camera.ScreenToWorldPoint(mousePos);        
        //firingDirection = firingDirection - GameObject.Find("Player").GetComponent<Transform>().position;
        //firingDirection = firingDirection.normalized;

        //m_RB.velocity = firingDirection;


        m_RB = GetComponent<Rigidbody>();
        m_player = GameObject.Find("Player");

        m_RB.velocity = m_player.GetComponent<FiringController>().GetProjectileVelocity();

        m_player.GetComponent<FiringController>().ResetVelocity();
     
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "Player")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
