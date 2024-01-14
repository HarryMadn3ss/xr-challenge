using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject m_pickup;

    // Start is called before the first frame update
    void Start()
    {
        int seed = (int)Time.realtimeSinceStartup * Random.Range(0, 500);
        Random.InitState(seed);
        for(int i = 0; i <= 4; i++)
        {
            Instantiate(m_pickup, new Vector3(Random.Range(10.0f, 40.0f), 0, Random.Range(10.0f, 40.0f)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawn enimies

    }


    public void ChangeScene()
    {
        Scene nextScene = SceneManager.GetSceneAt(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.SetActiveScene(nextScene);
    }
}
