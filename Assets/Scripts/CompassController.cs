using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    GameObject[] m_starPickups;

    float m_distance;
    float m_smallestDist = 1000000000;
    GameObject m_closestStar;

    GameObject m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_starPickups = GameObject.FindGameObjectsWithTag("Star");
        m_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        m_starPickups = GameObject.FindGameObjectsWithTag("Star");

        for (int i = 0; i < m_starPickups.Length; i++)
        {
            m_distance = Vector3.Magnitude(m_starPickups[i].transform.position - m_player.transform.position);

            if(m_distance < m_smallestDist)
            {
                m_smallestDist = m_distance;
                m_closestStar = m_starPickups[i];
            }                
        }

        Vector3 direction = m_closestStar.transform.position - m_player.transform.position;
        transform.rotation = Quaternion.Euler(0, 0, -Quaternion.LookRotation(direction).eulerAngles.y); 

        m_closestStar = null;
        m_starPickups = null;
        m_smallestDist = 1000000000;        

    }
}
