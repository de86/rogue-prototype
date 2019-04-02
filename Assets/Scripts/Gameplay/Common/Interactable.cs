using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private BoxCollider2D boxCollider;


	private void Start () {
		boxCollider = GetComponent<BoxCollider2D>();
	}
	

	private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Press Y to interact");
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit interaction collider");
    }
}
