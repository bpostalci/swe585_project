using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCastles : MonoBehaviour
{
    private const string m_WarCastleTag = "WarCastle";
    private UIController m_UIController;
    private const string m_UIControllerTag = "UIController";

    void Start() {
        m_UIController = GameObject.Find(m_UIControllerTag).GetComponent<UIController>();
        UpdateRemainingWarCastles();
    }

    public void UpdateRemainingWarCastles() {
        int numberOfWarCastles= GameObject.FindGameObjectsWithTag(m_WarCastleTag).Length;
        m_UIController.UpdateRemainingWarCastles(numberOfWarCastles);
        if(numberOfWarCastles == 0) {
            m_UIController.WinGame();
        }
    }
}
