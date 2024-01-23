using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject m_enemy;

    public float m_spawnRate = 3;

    GameObject[] m_enemies;

    // Update is called once per frame
    void Update()
    {
        m_enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(m_enemies.Length < 50 )
        {
            if(m_spawnRate < 0)
            {
                Instantiate(m_enemy, transform.position, Quaternion.identity);
                m_spawnRate = 2;
            }
            else
            {
                m_spawnRate -= Time.deltaTime;
            }
        }
        
    }
}
