using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
	public GameObject Projectile;
	public float ProjectileBaseSpeed;

    void Start()
    {
    }
	
    void Update()
    {
    }

	public void FireProjectile(Projectile.Direction dir)
	{
		GameObject thisProj = Instantiate(Projectile, GetComponent<PlayerMovement>().Head.transform.position, transform.rotation);
		Projectile proj = thisProj.GetComponent<Projectile>();

		proj.thisDir = dir;
		proj.ProjSpeed = ProjectileBaseSpeed;
	}
}
