using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
	public GameObject Player;

	private ParticleSystem emitter;
	private ParticleSystem.Particle[] particles;

	// Start is called before the first frame update
	void Start()
	{
		emitter = GetComponent<ParticleSystem>();
		particles = new ParticleSystem.Particle[emitter.main.maxParticles];
	}

	// Update is called once per frame
	void Update()
	{
		int numParticles = emitter.GetParticles(particles);

		for (int i = 0; i < numParticles; ++i)
		{
			ref var particle = ref particles[i];
			var distance = Vector3.Distance(particle.position, Player.transform.position);

			if (particle.remainingLifetime < 2)
			{
				particle.position = Vector3.MoveTowards(particle.position, Player.transform.position, Time.deltaTime * 5);
			}
		}

		emitter.SetParticles(particles);
	}
}
