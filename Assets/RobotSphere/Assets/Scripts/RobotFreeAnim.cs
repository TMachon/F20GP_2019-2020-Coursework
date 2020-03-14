using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	float movementSpeed = 0.4f;
	Animator anim;
	bool moving;
	int wait;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
		wait = 0;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
		if (moving)
		{
			if (wait < 340)
            {
				wait++;
            }
			else
            {
				gameObject.transform.position += gameObject.transform.forward * Time.fixedDeltaTime * movementSpeed;
			}
		}
	}

	void CheckKey()
    {
		if (Input.GetKeyDown(KeyCode.UpArrow) && !moving)
		{
			rot[1] = 0;
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) && !moving)
		{
			rot[1] = 180;
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) && !moving)
		{
			rot[1] = 270;
		}
		if (Input.GetKeyDown(KeyCode.RightArrow) && !moving)
		{
			rot[1] = 90;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			wait = 0;
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
				moving = false;
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
				moving = true;
			}
		}
	}

	public void Stop()
    {
		anim.SetBool("Roll_Anim", false);
		moving = false;
	}

	void OldCheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			rot[1] -= rotSpeed * Time.fixedDeltaTime;
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			rot[1] += rotSpeed * Time.fixedDeltaTime;
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}
