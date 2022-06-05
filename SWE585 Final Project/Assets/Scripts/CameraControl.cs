using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private float m_ZSpeed;
    private Vector3 m_MvVelocity;
    public Transform[] m_ObjectsToFollow;
    private Camera m_Camera;
    private Vector3 m_Pos;
    private void CalculateAvgPos()
    {
        Vector3 avgP = new Vector3();
        int numberOfObjects = 0;
        for (int i = 0; i < m_ObjectsToFollow.Length; i++)
        {
            if (!m_ObjectsToFollow[i].gameObject.activeSelf)
                continue;
            avgP += m_ObjectsToFollow[i].position;
            numberOfObjects++;
        }
        if (numberOfObjects > 0)
        {
            avgP = avgP / numberOfObjects;
        }
        avgP.y = transform.position.y;
        m_Pos = avgP;
    }
    private void FixedUpdate()
    {
        CalculateAvgPos();
        transform.position = Vector3.SmoothDamp(transform.position, m_Pos, ref m_MvVelocity, 0.2f);
        float requiredSize = CalculateSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, requiredSize, ref m_ZSpeed, 0.2f);
    }
    private void Awake()
    {
        m_Camera = GetComponentInChildren<Camera>();
    }
    private float CalculateSize()
    {
        Vector3 localPos = transform.InverseTransformPoint(m_Pos);
        float size = 0f;
        for (int i = 0; i < m_ObjectsToFollow.Length; i++)
        {
            if (!m_ObjectsToFollow[i].gameObject.activeSelf)
            {
                continue;
            }
            Vector3 newLocalPos = transform.InverseTransformPoint(m_ObjectsToFollow[i].position);
            Vector3 posToNew = newLocalPos - localPos;
            size = GetMaxSize(size, Mathf.Abs(posToNew.y));
            size = GetMaxSize(size, Mathf.Abs(posToNew.x) / m_Camera.aspect);
        }
        size += 4f;
        size = Mathf.Max(size, 6.5f);
        return size;
    }

    private float GetMaxSize(float size, float target)
    {
        return Mathf.Max(size, target);
    }


}