using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarCastleShooting : MonoBehaviour
{
    private const string m_ShootKey = "space";

    private string m_FireButton;
    private float m_LaunchForce;
    private bool m_Shot;
    private float m_MinimumLaunchForce = 15f;
    public Rigidbody m_Shell;
    public Transform m_FireTransform;
    public Transform m_TankTransform;
    public AudioSource m_ShootingAudio;
    public AudioClip m_FireClip;


    private float nextActionTime = 0.0f;
    public float period = 0.9f;




    private void Start()
    {
        StartCoroutine("ShootPeriodically");
    }
    private void OnEnable()
    {
        m_LaunchForce = m_MinimumLaunchForce;
    }
    private void Update()
    {

    }

    IEnumerator ShootPeriodically()
    {
        for (; ; )
        {
            Shoot();
            yield return new WaitForSeconds(Random.Range(2f, 10f));
        }
    }

    private void Shoot()
    {
        m_Shot = true;
        Rigidbody shellInstance = Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_LaunchForce * m_FireTransform.forward;
        m_LaunchForce = m_MinimumLaunchForce;
        m_ShootingAudio.clip = m_FireClip;
        m_ShootingAudio.Play();
    }
}
