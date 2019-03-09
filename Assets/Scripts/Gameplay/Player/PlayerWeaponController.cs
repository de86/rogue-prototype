using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    private Animator animator;

    private float xAxisValue;
    private float lastXAxisValue = 0;
    private float attackDirection;



	// Use this for initialization
	private void Start () {
		animator = GetComponent<Animator>();
	}
	


	// Update is called once per frame
	private void Update () {
        SetAnimatorAttackDirection();

        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(TriggerAttackAnimation());
        }
	}



    private IEnumerator TriggerAttackAnimation ()
    {
        animator.SetBool("isAttacking", true);
        yield return null;
        animator.SetBool("isAttacking", false);
    }



    private void SetAnimatorAttackDirection ()
    {
        xAxisValue = Input.GetAxis("Horizontal");

        if (xAxisValue > 0.4 || xAxisValue < -0.4)
        {
            if (xAxisValue > 0)
            {
                animator.SetFloat("attackDirection", 1f);
            }
            else
            {
                animator.SetFloat("attackDirection", 0f);
            }
        }
        else
        {
            animator.SetFloat("attackDirection", lastXAxisValue);
        }

        lastXAxisValue = xAxisValue;
    }
}
