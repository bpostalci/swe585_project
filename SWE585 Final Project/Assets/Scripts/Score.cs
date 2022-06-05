using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int m_Score = 0;

    public void IncrementScore() {
        m_Score++;
        Debug.Log("score: "+m_Score);
    }
}
