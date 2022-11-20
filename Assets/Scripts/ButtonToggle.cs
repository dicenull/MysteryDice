using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    Animator animator;
	const String buttonAnimateName = "Enable";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

	private void Update()
	{
		if(Input.GetMouseButtonDown(0))
		{
			animator.SetBool(buttonAnimateName, true);
		}
		if (Input.GetMouseButtonDown(1))
		{

			animator.SetBool(buttonAnimateName, false);
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		var prevState = animator.GetBool(buttonAnimateName);

		animator.SetBool(buttonAnimateName, !prevState);
	}
}
