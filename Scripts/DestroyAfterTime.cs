using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
	public ParticleSystem particle;
	private void Start()
	{
		Destroy(gameObject, particle.main.duration);
	}
}
