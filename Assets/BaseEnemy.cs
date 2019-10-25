using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
	public float Health;

	public virtual void TakeDamage(int dmg)
	{
		if (Health > dmg)
		{
			Health -= dmg;
		}
		else
		{
			Die();
		}
	}

	public virtual void Die()
	{
		Destroy(this.gameObject);
	}
}
