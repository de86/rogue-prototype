using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {

    [SerializeField]
	private float MAX_MOVE_SPEED = 6f;
    [SerializeField]
	private float MAX_BLOCK_MOVE_SPEED = 2f;
    [SerializeField]
	private float MAX_DODGE_SPEED = 15f;
    [SerializeField]
    private float DODGE_COOLDOWN_TIME = 0.2f;
    [SerializeField]
    private float ACCELERATION = 0.95f;
    [SerializeField]
    private float DECELERATION = 0.9f;
    [SerializeField]
    private float CONTROLLER_DEAD_ZONE = 0.2f;
    [SerializeField]
    private FloatVariable playerDirection;

    private float speed = 0f;
    private float dodgeSpeed;
    private float xAxisValue;
    private float yAxisValue;

    private Boolean canDodge = true;

    private Vector2 velocity = Vector2.zero;
    private Vector2 direction = Vector2.zero;
    private Vector2 lastMoveDirection = Vector2.zero;

    private enum MovementState
    {
        Walking,
        Dodging,
        Blocking
    };
    [SerializeField]
    private MovementState currentMovementState = MovementState.Walking;



    private void Start ()
    {
        dodgeSpeed = MAX_DODGE_SPEED;
    }



    private void Update ()
    {
        xAxisValue = Input.GetAxis("Horizontal");
        yAxisValue = Input.GetAxis("Vertical");

        if (currentMovementState == MovementState.Walking && Input.GetButtonDown("Fire2") && canDodge)
        {
            currentMovementState = MovementState.Dodging;
        }
        else if (Input.GetButtonDown("Block"))
        {
            currentMovementState = MovementState.Blocking;
        }
    }



	private void FixedUpdate ()
    {
        switch (currentMovementState)
        {
            case MovementState.Walking:
                Walk();
                break;

            case MovementState.Dodging:
                Dodge();
                break;

            case MovementState.Blocking:
                Block();
                break;

            default:
                break;
        };
	}


    
    private void Walk ()
    {
        SetDirection();

        if (CanMove(xAxisValue) || CanMove(yAxisValue))
        {
            speed = Math.Min(speed += ACCELERATION, MAX_MOVE_SPEED);
            direction.Set(xAxisValue, yAxisValue);
            SetLastMoveDirection(direction);
            velocity = direction.normalized * speed * Time.deltaTime;
        }
        else
        {
            speed = Math.Max(speed -= DECELERATION, 0);
            velocity = lastMoveDirection  * speed * Time.deltaTime;
        }

        if (speed > 0)
        {
            transform.Translate(velocity);
        }
    }



    private void Dodge ()
    {
        canDodge = false;

        SetLastMoveDirection(direction);
        velocity = direction.normalized * dodgeSpeed * Time.deltaTime;
        transform.Translate(velocity);

        dodgeSpeed -= DECELERATION;

        if (dodgeSpeed < 5)
        {
            dodgeSpeed = MAX_DODGE_SPEED;
            currentMovementState = MovementState.Walking;
            StartCoroutine("StartDodgeCooldown");
        }
    }



    private IEnumerator StartDodgeCooldown ()
    {
        yield return new WaitForSeconds(DODGE_COOLDOWN_TIME);
        canDodge = true;
    }



    private void Block ()
    {
        if (CanMove(xAxisValue) || CanMove(yAxisValue))
        {
            direction.Set(xAxisValue, yAxisValue);
            SetLastMoveDirection(direction);
            velocity = direction * MAX_BLOCK_MOVE_SPEED * Time.deltaTime;
        }
        else
        {
            velocity = Vector2.zero;
        }

        transform.Translate(velocity);

        if (!Input.GetButton("Block"))
        {
            currentMovementState = MovementState.Walking;
        }
    }


    private Boolean CanMove (float axis)
    {
        return axis > CONTROLLER_DEAD_ZONE || axis < -CONTROLLER_DEAD_ZONE;
    }


    private void SetDirection ()
    {
        if (CanMove(xAxisValue)) {
            float facingDirection = xAxisValue > 0 ? 1f : 0f;
            playerDirection.SetValue(facingDirection);
        }
    }

    private void SetLastMoveDirection (Vector2 direction)
    {
        lastMoveDirection = direction.normalized;
    }
}
