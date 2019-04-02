using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour {

    [SerializeField]
    private FloatVariable playerDirection;

    private float lastPlayerDirection;
    private BoxCollider2D interactionBox;


	private void Start ()
    {
		interactionBox = GetComponent<BoxCollider2D>();
	}
	


	private void Update ()
    {
		if (hasChangedDirection())
        {
            UpdateInteractionBoxPosition();
        }

        UpdateLastPlayerDirection();
	}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Can interactive with: " + collision.gameObject.name);
    }



    private bool hasChangedDirection ()
    {
        return lastPlayerDirection != playerDirection.GetValue();
    }




    private void UpdateLastPlayerDirection ()
    {
        lastPlayerDirection = playerDirection.GetValue();
    }



    private void UpdateInteractionBoxPosition ()
    {
        float offsetX = interactionBox.offset.x;
        float offsetY = interactionBox.offset.y;
        interactionBox.offset = new Vector2(-offsetX, offsetY);
    }
}
