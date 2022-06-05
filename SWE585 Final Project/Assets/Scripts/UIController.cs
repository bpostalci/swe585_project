using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject m_WinText;
    private GameObject m_LoseText;

    void Start()
    {
        GameObject.Find("RestartButton").GetComponentInChildren<Text>().text="Restart";
        m_WinText=GameObject.Find("WinText");
        m_WinText.SetActive(false);
        m_LoseText=GameObject.Find("LoseText");
        m_LoseText.SetActive(false);
    }

    public void UpdateScore(int score) {
        GameObject.Find("ScoreText").GetComponentInChildren<Text>().text = "Score: " + score;
    }

    public void UpdateRemainingWarCastles(int numberOfCastles) {
        GameObject.Find("RemainingWarCastlesText").GetComponentInChildren<Text>().text = "Remaining castles: " + numberOfCastles;
    }

    public void WinGame( ) {
        m_WinText.SetActive(true);
    }

    public void LoseGame() {
        m_LoseText.SetActive(true);
    }

    public void RestartGame() {
        SceneManager.LoadScene( SceneManager.GetActiveScene().name );
    }
}
