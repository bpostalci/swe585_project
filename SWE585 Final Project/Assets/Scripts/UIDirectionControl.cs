using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour
{
    public bool m_RelRotation = true;
    private Quaternion m_RelativeRotation;
    private void Update()
    {
        if (m_RelRotation)
        {
            transform.rotation = m_RelativeRotation;

        }
    }
    private void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }



}
