using UnityEngine;

public class ShellExplosion : MonoBehaviour
{
    public const int m_TankDamage = 10;
    public const int m_WarCastleDamage = 15;
    public LayerMask m_TankMask;
    public ParticleSystem m_ExplosionParticles;
    public AudioSource m_ExplosionAudio;


    private void Start()
    {
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter(Collider other)
    {
        Collider[] cs = Physics.OverlapSphere(transform.position, 5f, m_TankMask);
        for (int i = 0; i < cs.Length; i++)
        {
            Rigidbody rBody = cs[i].GetComponent<Rigidbody>();
            if (!rBody)
            {
                continue;
            }
            rBody.AddExplosionForce(1000f, transform.position, 5f);

            if (rBody.GetComponent<WarCastleHealth>() != null)
            {
                WarCastleHealth health = rBody.GetComponent<WarCastleHealth>();
                health.Damage(m_WarCastleDamage);
            }
            else if (rBody.GetComponent<TankHealth>() != null)
            {
                TankHealth health = rBody.GetComponent<TankHealth>();
                health.Damage(m_TankDamage);
            }
            else
            {
                continue;
            }
        }

        m_ExplosionParticles.transform.parent = null;
        m_ExplosionParticles.Play();
        m_ExplosionAudio.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.duration);
        Destroy(gameObject);
    }
}