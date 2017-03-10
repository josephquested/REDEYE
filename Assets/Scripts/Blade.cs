using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;
	Rigidbody rb;
	AudioSource audioSource;
	ParticleSystem particles;
	CameraShake cameraShake;

	public GameObject blade;
	public float heat;
	public float heatSpeed;
	public float thrust;
	public float cooldown;
	public float knockback;
	public bool firing;

	void Start ()
	{
		particles = blade.GetComponentsInChildren<ParticleSystem>()[0];
		audioSource = blade.GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		cameraShake = GetComponentsInChildren<CameraShake>()[0];
	}

	void Update ()
	{
		UpdateAnimator();
		UpdateParticles();
		UpdateCameraShake();
	}

	public void ReceiveInput (bool shouldHeat)
	{
		if (shouldHeat)
		{
			animator.SetBool("blade-heating", true);

			if (heat < 1)
			{
				heat += heatSpeed;
			}
			else
			{
				heat = 1;
			}
		}

		else
		{
			animator.SetBool("blade-heating", false);

			if (heat > 0)
			{
				heat -= heatSpeed;
			}
			else
			{
				heat = 0;
			}
		}
	}

	public void AttemptFire ()
	{
		if (heat >= 0.99f && !firing)
		{
			animator.SetTrigger("blade-fire");
			StartCoroutine(FireRoutine());
		}
	}

	IEnumerator FireRoutine ()
	{
		firing = true;
		audioSource.Play();
		rb.AddForce(transform.forward * thrust);
		yield return new WaitForSeconds(cooldown);
		firing = false;
	}

	public void Strike (Collider collider)
	{
		if (collider.gameObject.GetComponent<Knockback>() != null)
		{
			Vector3 direction = transform.parent.forward;
			collider.gameObject.GetComponent<Knockback>().ReceiveKnockback(direction, knockback);
		}
		collider.gameObject.GetComponent<Status>().Damage(2);
		rb.velocity = Vector3.zero;
	}

	void UpdateParticles ()
	{
		if (heat > 0.99f && !firing)
		{
			particles.Play();
		}
		else
		{
			particles.Stop();
		}
	}

	void UpdateCameraShake ()
	{
		cameraShake.ReceiveInput(heat);
	}

	public void UpdateAnimator ()
	{
		if (heat >= 0.99)
		{
			animator.SetBool("blade-hot", true);
		}
		else
		{
			animator.SetBool("blade-hot", false);
		}
	}
}
