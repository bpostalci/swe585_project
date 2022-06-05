using UnityEngine;
using UnityEngine.UI;

public class TankShooting : MonoBehaviour
{
    private const string m_ShootKey = "space";

    private string m_FireButton;
    private float m_LaunchForce;
    private float m_ChargeSpeed;
    private bool m_Shot;
    private float m_MaximumChargeTime = 0.85f;
    private float m_MinimumLaunchForce = 15f;
    private float m_MaximumLaunchForce = 30f;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_ChargingClip;
    public AudioClip m_FireClip;







    private void Start()
    {
        m_ChargeSpeed = (m_MaximumLaunchForce - m_MinimumLaunchForce) / m_MaximumChargeTime;
    }
    private void OnEnable()
    {
        m_LaunchForce = m_MinimumLaunchForce;
    }
    private void Update()
    {

        if (m_LaunchForce >= m_MaximumLaunchForce && !m_Shot)
        {
            m_LaunchForce = m_MaximumLaunchForce;
            m_Shot = true;
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
            m_LaunchForce = m_MinimumLaunchForce;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
        }
        else if (Input.GetKeyDown(m_ShootKey))
        {
            m_Shot = false;
            m_LaunchForce = m_MinimumLaunchForce;
            m_ShootingAudio.clip = m_ChargingClip;
            m_ShootingAudio.Play();
        }
        else if (Input.GetKey(m_ShootKey) && !m_Shot)
        {
            m_LaunchForce += m_ChargeSpeed * Time.deltaTime;
        }
        else if (Input.GetKeyUp(m_ShootKey) && !m_Shot)
        {
            m_Shot = true;
            Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
            shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
            m_LaunchForce = m_MinimumLaunchForce;
            m_ShootingAudio.clip = m_FireClip;
            m_ShootingAudio.Play();
        }
    }

}