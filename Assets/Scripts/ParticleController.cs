using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	public GameObject Player;

	private ParticleSystem emitter;

	// Start is called before the first frame update
	void Start()
	{
		emitter = GetComponent<ParticleSystem>();
	}

	// Update is called once per frame
	void Update()
	{
		ParticleSystem.Particle[] particles = new ParticleSystem.Particle[emitter.main.maxParticles];
		int numParticles = emitter.GetParticles(particles);

		for (int i = 0; i < numParticles; ++i)
		{
			ref var particle = ref particles[i];
			var distance = Vector3.Distance(particle.position, Player.transform.position);

			if (particle.remainingLifetime < 2.5f)
			{
				if (distance >= 0.1f)
				{
					particle.position = Vector3.MoveTowards(particle.position, Player.transform.position, Time.deltaTime * 8);
				}
				else
				{
					particle.remainingLifetime = -1;
				}
			}
		}

		emitter.SetParticles(particles);
	}
}
