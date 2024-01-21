using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject m_enemy;

    public float m_spawnRate = 2;  

    // Update is called once per frame
    void Update()
    {
        if(m_spawnRate < 0)
        {
            Instantiate(m_enemy, transform);
            m_spawnRate = 2;
        }
        else
        {
            m_spawnRate -= Time.deltaTime;
        }
    }
}
