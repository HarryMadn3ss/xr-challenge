using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject m_pickup;
    public bool m_gameOver = false;
    GameObject m_gameOverUI;
    public GameObject m_enemySpawner;
  

    // Start is called before the first frame update
    void Start()
    {
        m_gameOver = false;
        m_gameOverUI = GameObject.Find("GameOver");
        m_gameOverUI.SetActive(m_gameOver);

        int systemTime = System.DateTime.Now.Millisecond;        
        Random.InitState(systemTime);
        for(int i = 0; i <= 4; i++)
        {
            Instantiate(m_pickup, new Vector3(Random.Range(10.0f, 40.0f), 0, Random.Range(10.0f, 40.0f)), Quaternion.identity);
        }
        
        Instantiate(m_enemySpawner, new Vector3(2f, 0.2f, 2f), Quaternion.identity);
        Instantiate(m_enemySpawner, new Vector3(2f, 0.2f, 48f), Quaternion.identity);
        Instantiate(m_enemySpawner, new Vector3(48f, 0.2f, 2f), Quaternion.identity);
        Instantiate(m_enemySpawner, new Vector3(48f, 0.2f, 48f), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {       
     

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void ResetScene()
    {
        if(m_gameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }
    }

    public void SetGameOver()
    {
        m_gameOver = true;
        m_gameOverUI.SetActive(m_gameOver);
    }

    public bool GetGameOver() { return m_gameOver; }
}
