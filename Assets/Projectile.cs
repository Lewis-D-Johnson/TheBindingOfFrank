using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	public enum Direction { Up, Left, Down, Right }
	public Direction thisDir;
	public float ProjSpeed;

	SpriteRenderer sr;

	private void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		Destroy(this.gameObject, 6f);
	}

	void Update()
    {
		switch (thisDir)
		{
			case Direction.Up:
				sr.sortingOrder = 0;
				transform.Translate(transform.up * ProjSpeed);
				break;
			case Direction.Left:
				sr.sortingOrder = 2;
				transform.Translate(-transform.right * ProjSpeed);
				break;
			case Direction.Down:
				sr.sortingOrder = 2;
				transform.Translate(-transform.up * ProjSpeed);
				break;
			case Direction.Right:
				sr.sortingOrder = 2;
				transform.Translate(transform.right * ProjSpeed);
				break;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		print("HIT");
		if (collision.gameObject.GetComponent<BaseEnemy>())
		{
			BaseEnemy enemy = collision.gameObject.GetComponent<BaseEnemy>();

			enemy.TakeDamage(25);
			Destroy(this.gameObject);
		}
	}
}
