using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] Animator AnimLegs;
	[SerializeField] float SpeedModifier;
	public SpriteRenderer Head;
	PlayerCombat PlayerCombat;
	bool canMoveHead = true;

	public bl_Joystick MovementJoystick;
	public bl_Joystick CombatJoystick;

	public List<Sprite> HeadDirection = new List<Sprite>();

	private void Start()
	{
		PlayerCombat = GetComponent<PlayerCombat>();
	}

	void Update()
    {
		transform.Translate(transform.right * (MovementJoystick.Horizontal / SpeedModifier));
		transform.Translate(transform.up * (MovementJoystick.Vertical / SpeedModifier));

		if (MovementJoystick.Horizontal > 0.1f)
		{
			AnimLegs.transform.localScale = new Vector3(1, 1, 1);
			AnimLegs.Play("WalkLeft_Right", 0);
		}
		else if (MovementJoystick.Horizontal < -0.1f)
		{
			AnimLegs.transform.localScale = new Vector3(-1, 1, 1);
			AnimLegs.Play("WalkLeft_Right", 0);
		}
		else if(MovementJoystick.Vertical != 0)
		{
			AnimLegs.Play("WalkUp_Down", 0);
		}
		else
		{
			AnimLegs.Play("New State", 0);
		}

		if (canMoveHead)
		{
			if (Input.GetKeyDown(KeyCode.LeftArrow) || CombatJoystick.Horizontal < -0.75f && CombatJoystick.Vertical > -1f && CombatJoystick.Vertical < 1f)
			{
				StartCoroutine(ChangeHeadDirection(HeadDirection[6], Projectile.Direction.Left));
			}
			else if (Input.GetKeyDown(KeyCode.RightArrow) || CombatJoystick.Horizontal > 0.75f && CombatJoystick.Vertical > -1f && CombatJoystick.Vertical < 1f)
			{
				StartCoroutine(ChangeHeadDirection(HeadDirection[2], Projectile.Direction.Right));
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow) || CombatJoystick.Vertical > 0.75f && CombatJoystick.Horizontal > -1f && CombatJoystick.Horizontal < 1f)
			{
				StartCoroutine(ChangeHeadDirection(HeadDirection[4], Projectile.Direction.Up));
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow) || CombatJoystick.Vertical < -0.75f && CombatJoystick.Horizontal > -1f && CombatJoystick.Horizontal < 1f)
			{
				StartCoroutine(ChangeHeadDirection(HeadDirection[0], Projectile.Direction.Down));
			}
		}
	}

	IEnumerator ChangeHeadDirection(Sprite newHead, Projectile.Direction dir)
	{
		canMoveHead = false;
		Sprite oldHead = Head.sprite;
		Head.sprite = newHead;
		yield return new WaitForSeconds(0.1f);

		Head.sprite = HeadDirection[HeadDirection.IndexOf(newHead) + 1];
		PlayerCombat.FireProjectile(dir);

		yield return new WaitForSeconds(0.2f);

		canMoveHead = true;
		Head.sprite = oldHead;
	}
}
