using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.AI;
using UnityEngine.UI;
using System;

public class EnemyTank : MonoBehaviour
{
    public float health,maxHealth,range_radius,time,sTime;
	public int shootDelay_ms;
	public ParticleSystem destroyExplosion;
	public Slider healthSlider;
	public Transform target,turrent,firepoint,destination;
	public GameObject shell;
	public bool exit;
	public LayerMask Targetlayer;
    public NavMeshAgent agent;
	public AudioSource shotAudio;
	//public delegate void Fixed_Action(NavMeshAgent agent,Transform t);

    Vector3 dir;
	Quaternion rotat;

    private void Start()
    {
		
    }

    public void HealthChange(float value)
	{
        if(value + health <= 0) DestroyTank(); else
		{
			health += value;
			healthSlider.value = health / maxHealth;
		}

	}

	public void DestroyTank()
	{
		ParticleSystem e = Instantiate(destroyExplosion);
		e.transform.position = transform.position;
		FindObjectOfType<GameSupervisor>().CheckGameState();
		Destroy(gameObject);
		
	}

	public void RotateTurrentTowardsTarget()
	{
		rotat = Quaternion.LookRotation(dir);
		rotat.x = rotat.z = 0;
		turrent.transform.rotation = rotat;
	}

	public async void Shoot()
	{
		while(!exit)
		{
			//await Task.Delay(shootDelay_ms);
			if (exit) return;
			GameObject SHELL = Instantiate(shell);
			SHELL.transform.GetComponent<Projectile>().type = Projectile.Type.enemyProjectile;
			SHELL.transform.position = firepoint.position;
			SHELL.transform.rotation = turrent.transform.rotation;
			SHELL.GetComponent<Rigidbody>().AddForce(turrent.transform.forward * 22, ForceMode.VelocityChange);
			shotAudio.Play();
			await Task.Yield();
			
		}
	}

	public void Hit(float value)
	{
		HealthChange(value);
	}



    private void Update()
    {
        TargetDetection();
    }

 

    void TargetDetection()
    {
        Collider[] hit = Physics.OverlapSphere(turrent.position, range_radius,Targetlayer);



		//if(hit!=null)
		for(int i = 0; i < hit.Length; i++)
        {
            if (hit[i].tag!=null)
			if (hit[i].CompareTag("Player"))
			{
				destination = hit[i].transform;
				dir = target.position - turrent.position;
				RotateTurrentTowardsTarget();
				agent.destination = destination.transform.position;
				
				RaycastHit t;
				Physics.Raycast(turrent.position, turrent.forward, out t, range_radius);
				
					if(t.collider != null)
				if (t.collider.CompareTag("Player")&&Wait())
				{
					exit = false;
					Shoot();
					sTime = time;
					exit = true;
                }

            }

        }
        
    }

	bool Wait()
    {
		if(sTime<=0) return true;
		else
        {
			sTime -= Time.deltaTime;
			return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, range_radius);
    }
}
