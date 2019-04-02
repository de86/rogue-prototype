using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

    private Animator animator;

    [SerializeField]
    private FloatVariable playerDirection;

    private float xAxisValue;
    private float lastXAxisValue = 0;
    private float attackDirection;



	// Use this for initialization
	private void Start () {
		animator = GetComponent<Animator>();
	}
	

	// Update is called once per frame
	private void Update () {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(TriggerAttackAnimation());
        }
	}


    private IEnumerator TriggerAttackAnimation ()
    {
        animator.SetFloat("attackDirection", playerDirection.GetValue());
        animator.SetBool("isAttacking", true);
        yield return null;
        animator.SetBool("isAttacking", false);
    }
}
