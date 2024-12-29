using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Projectile : MonoBehaviour,IHitable
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".
    public ParticleSystem explosionParticles;         // Reference to the particles that will play on explosion.
    public AudioSource explosionAudio;                // Reference to the audio that will play on explosion.
    public Rigidbody rb;
    public CapsuleCollider coli;
    public float lifeTime,force,destructiveForce;
    public enum Type
    {
        enemyProjectile,playerProjectile
    }
    float explosionRadius;
    int count;
    public Type type;

    private void Start()
    {
        explosionRadius = transform.GetComponent<CapsuleCollider>().radius;
        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, lifeTime);
        //await Task.Delay((int)lifeTime*1000); Destroy(gameObject);
    }


    public void OnCollisionEnter(Collision colli)
    {
        if (count < 1 && colli.collider.gameObject.layer < 9)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.Reflect(rb.linearVelocity, colli.contacts[0].normal), Vector3.up);
            rb.linearVelocity = Vector3.zero;
            rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
            rb.angularVelocity = Vector3.zero;
            rb.angularDamping = 0;
            count++;
            
        }else
		{
            if (colli.collider.gameObject.layer >= 9)
            {
                //Debug.Log(colli.collider.GetComponent<Player>().health);
                colli.collider.GetComponent<IHitable>().Hit(-12);
                Rigidbody r = colli.collider.GetComponent<Rigidbody>();
                r.angularVelocity = Vector3.zero;
                r.angularDamping = 0;
                r.linearVelocity = Vector3.zero;
            }
            explosionParticles.transform.parent = null;
            explosionParticles.Play();
            explosionAudio.Play();
            Destroy(gameObject);
        }


    }


	private void OnDrawGizmos()
	{
        Debug.DrawRay(transform.position, transform.forward,Color.blue);
	}

	public void Hit(float value)
	{
	}
}

