using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dronefly : MonoBehaviour {
	Rigidbody rb;
	Transform target;
	Animator animator;
	Shake shake;
	AudioSource audioSource;

	public DroneflyAttackTrigger attackTrigger;
	public AudioClip explodePlayerClip;

  public float speed;
  public float cooldown;
	public bool striking;

	bool bakingPlayer;
	bool destroyedPlayer;
	public float bake;
	public float bakeSpeed;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		shake = GameObject.FindWithTag("MainCamera").GetComponent<Shake>();
		target = GameObject.FindWithTag("Player").transform;
		audioSource = GetComponent<AudioSource>();
	}

  void Update ()
	{
		FacePlayer();
		Rise();
		UpdateBake();

		if (!striking)
		{
			StartCoroutine(StrikeRoutine());
		}
  }

	IEnumerator StrikeRoutine ()
	{
		striking = true;
		yield return new WaitForSeconds(cooldown);
		striking = false;
		Strike();
	}

	void FacePlayer ()
	{
		Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10000, 0.0F);
    transform.rotation = Quaternion.LookRotation(newDir);
	}

	void UpdateBake ()
	{
		if (attackTrigger.inTrigger)
		{
			bake += bakeSpeed;
			shake.ReceiveInput(bake * 4);
		}
		else
		{
			bake -= bakeSpeed;
		}
		if (bake >= 1 && !destroyedPlayer)
		{
			if (GameObject.FindWithTag("Player") != null)
			{
				GameObject.FindWithTag("Player").GetComponent<Status>().Die();
				destroyedPlayer = true;
				audioSource.pitch = 1;
				audioSource.clip = explodePlayerClip;
				audioSource.loop = false;
				audioSource.Play();
			}
		}
		if (bake < 0)
		{
			bake = 0;
		}
	}

	void Strike ()
	{
		rb.velocity = transform.forward * speed;
	}

	void Rise ()
	{
		rb.AddForce(Vector3.up * 2);
	}
}
