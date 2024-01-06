using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int m_score;
    private float m_timer;

    TextMeshProUGUI m_scoreText;
    TextMeshProUGUI m_timerText;

    private void Start()
    {
        m_score = 0;
        m_timer = 0;

        m_scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        m_scoreText.text = "Score: " + m_score.ToString();

        m_timerText = GameObject.Find("TimerText").GetComponent<TextMeshProUGUI>();
        m_timerText.text = "Timer: " + m_timer.ToString();
    }

    private void FixedUpdate()
    {
        m_timer += Time.deltaTime;
        m_timerText.text = "Timer: " + (Mathf.Round(m_timer * 100) / 100).ToString();
    }

    public void IncreaseScore(int scoreToIncrease)
    {
        m_score += scoreToIncrease;
        m_scoreText.text = m_scoreText.text = "Score: " + m_score.ToString();
    }

}
