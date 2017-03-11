using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {
	Animator animator;

	public GameObject blade;
	public float heatSpeed;
	public float coolSpeed;
	public float heat;

	void Start ()
	{
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
		heat = 0;
	}
}
