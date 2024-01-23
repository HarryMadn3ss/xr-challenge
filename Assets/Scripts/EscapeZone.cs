using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    GameManager gameManager;

    private bool m_canEscape;

    private void Start()
    {
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();

        this.gameObject.SetActive(false);
        m_canEscape = false;
    }

    public void SetCanEscape(bool canEscaape) 
    {
        m_canEscape = canEscaape; 

        if (m_canEscape)
        {
            this.gameObject.SetActive(m_canEscape);
            //set escape ui to true

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (m_canEscape && this.isActiveAndEnabled && other.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().ChangeScene();
        }
    }
}
