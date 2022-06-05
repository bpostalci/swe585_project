using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WarCastleHealth : MonoBehaviour
{
    private const string m_WarCastleTag = "WarCastle";
    private const string m_ScoreTag = "Score";
    private const string m_TankTag = "Tank";
    private const string m_UIControllerTag = "UIController";
    public Slider m_Slider;
    public Image m_FillImage;
    public GameObject m_ExplosionPref;

    public float m_InitialHealth = 100f;

    private Score m_Score;

    private WarCastles m_WarCastles;
    private UIController m_UIController;
    private AudioSource m_ExplosionAudio;
    private ParticleSystem m_ExplosionParticles;
    private float m_Health;
    private bool m_Alive;


    private void Awake()
    {
        m_Score = GameObject.Find(m_ScoreTag).GetComponent<Score>();
        m_WarCastles = GameObject.FindGameObjectsWithTag(m_WarCastleTag)[0].GetComponent<WarCastles>();
        m_UIController = GameObject.Find(m_UIControllerTag).GetComponent<UIController>();
        m_ExplosionParticles = Instantiate(m_ExplosionPref).GetComponent<ParticleSystem>();
        m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource>();
        m_ExplosionParticles.gameObject.SetActive(false);
    }


    private void OnEnable()
    {
        m_Health = m_InitialHealth;
        m_Alive = true;
        UpdateHealthUI();
    }


    public void Damage(float amount)
    {
        m_Health -= amount;
        UpdateHealthUI();
        if (m_Alive && m_Health <= 0f)
        {
            Death();
        }
    }


    private void UpdateHealthUI()
    {
        m_Slider.value = m_Health;
        float newVal = m_Health / m_InitialHealth;
        m_FillImage.color = Color.Lerp(Color.red, Color.green, newVal);
    }


    private void Death()
    {
        m_ExplosionParticles.transform.position = transform.position;
        m_Score.IncrementScore();
        m_WarCastles.UpdateRemainingWarCastles();
        m_Alive = false;
        m_ExplosionParticles.gameObject.SetActive(true);
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        gameObject.SetActive(false);
    }
}
