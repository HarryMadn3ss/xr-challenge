using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    GameManager m_gameManager;

    private int m_score;
    private float m_timer;

    TextMeshProUGUI m_scoreText;
    TextMeshProUGUI m_timerText;

    GameObject m_EscapeZone;

    private void Start()
    {
        m_score = 0;
        m_timer = 0;

        m_gameManager = GameObject.Find("Managers").GetComponent<GameManager>();

        m_scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        m_scoreText.text = "Score: " + m_score.ToString();

        m_timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        m_timerText.text = "Timer: " + m_timer.ToString();

        m_EscapeZone = GameObject.Find("EscapeZone");
    }

    private void FixedUpdate()
    {
        if(m_gameManager.GetGameOver() == false)
        {
            m_timer += Time.deltaTime;
            m_timerText.text = "Timer: " + (Mathf.Round(m_timer * 100) / 100).ToString();
        }
        
    }

    public void IncreaseScore(int scoreToIncrease)
    {
        m_score += scoreToIncrease;

        if(m_score >= 500)
        {           
           m_EscapeZone.GetComponent<EscapeZone>().SetCanEscape(true);           
        }

        m_scoreText.text = m_scoreText.text = "Score: " + m_score.ToString();
    }

    

}
