using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int m_Score = 0;
    private UIController m_UIController;
    private const string m_UIControllerTag = "UIController";

    void Start() {
        m_UIController = GameObject.Find(m_UIControllerTag).GetComponent<UIController>();
        m_UIController.UpdateScore(0);
    }

    public void IncrementScore() {
        m_Score++;
        m_UIController.UpdateScore(m_Score);
    }
}
