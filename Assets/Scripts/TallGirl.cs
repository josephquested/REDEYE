﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TallGirl : MonoBehaviour {
	Rigidbody rb;
	Transform target;
	Animator animator;

  public float speed;
  public AudioSource attackAudio;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		target = GameObject.FindWithTag("Player").transform;
	}

  void Update ()
	{
		FacePlayer();
		MoveForward();
  }

	void FacePlayer ()
	{
		Vector3 targetDir = target.position - transform.position;
    Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 10000, 0.0F);
    transform.rotation = Quaternion.LookRotation(newDir);
	}

	void MoveForward ()
	{
		rb.velocity = transform.forward * speed;
	}

	public void Attack ()
	{
		animator.SetTrigger("attack");
		attackAudio.Play();
	}
}
