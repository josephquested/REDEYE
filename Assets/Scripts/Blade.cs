using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;
	Rigidbody rb;

	public GameObject blade;
	public int damage;
	public float heatSpeed;
	public float coolSpeed;
	public float heat;
	public float thrust;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	void Cool ()
	{
		if (heat <= 0)
		{
			heat = 0;
		}
		else
		{
			heat -= coolSpeed;
		}
	}

	//	FIRING	//

	public void Heat (bool shouldHeat)
	{
		animator.SetBool("blade-heat", shouldHeat);

		if (shouldHeat)
		{
			if (heat >= 1)
			{
				heat = 1;
			}
			else
			{
				heat += heatSpeed;
			}
		}
		else
		{
			Cool();
		}
	}

	public void AttemptFire ()
	{
		if (heat >= 0.95f)
		{
			Fire();
		}

		animator.SetBool("blade-heat", false);
	}

	void Fire ()
	{
		animator.SetTrigger("blade-fire");
		Thrust();
		heat = 0;
	}

	void Thrust ()
	{
		rb.AddForce(transform.forward * thrust);
	}

	public void ReceiveCollider (Collider collider)
	{
		if (collider.gameObject.GetComponent<Health>() != null)
		{
			collider.gameObject.GetComponent<Health>().Damage(damage);
			rb.velocity = rb.velocity / 2;
		}
	}
}
