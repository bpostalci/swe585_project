using UnityEngine;

public class TankMovement : MonoBehaviour
{

    public AudioClip m_DrivingAudioClip;
    private float m_TurnInput;
    private Rigidbody m_RgBody;
    private float m_MovementInputValue;
    private float m_MvPitch;
    public AudioSource m_MovementAudio;
    public AudioClip m_IdleAudio;
    private const string m_MovementAx = "Vertical1";
    private const string m_TurnAx = "Horizontal1";

    private void Awake()
    {
        m_RgBody = GetComponent<Rigidbody>();
    }


    private void OnEnable()
    {
        m_RgBody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInput = 0f;
    }


    private void OnDisable()
    {
        m_RgBody.isKinematic = true;
    }


    private void Start()
    {
        m_MvPitch = m_MovementAudio.pitch;
    }


    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MovementAx);
        m_TurnInput = Input.GetAxis(m_TurnAx);
        PlayTankAudio();
    }

    private void PlayTankAudio()
    {
        if (Mathf.Abs(m_MovementInputValue) >= 0.1f && Mathf.Abs(m_TurnInput) >= 0.1f)
        {
            if (m_MovementAudio.clip == m_IdleAudio)
            {
                m_MovementAudio.clip = m_DrivingAudioClip;
                m_MovementAudio.pitch = Random.Range(m_MvPitch - 0.2f, m_MvPitch + 0.2f);
                m_MovementAudio.Play();
            }

        }
        else if (m_MovementAudio.clip == m_DrivingAudioClip)
        {
            m_MovementAudio.clip = m_IdleAudio;
            m_MovementAudio.pitch = Random.Range(m_MvPitch - 0.2f, m_MvPitch + 0.2f);
            m_MovementAudio.Play();
        }
    }


    private void FixedUpdate()
    {
        Vector3 mov = transform.forward * m_MovementInputValue * 12f * Time.deltaTime;
        m_RgBody.MovePosition(m_RgBody.position + mov);
        float turn = m_TurnInput * 180f * Time.deltaTime;
        Quaternion turnRot = Quaternion.Euler(0f, turn, 0f);
        m_RgBody.MoveRotation(m_RgBody.rotation * turnRot);
    }
}