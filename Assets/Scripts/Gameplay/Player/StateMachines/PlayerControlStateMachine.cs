using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlStateMachine : StateMachine, IStateMachine {

    private void Start () {
        base.Init(new PlayerMovementState(gameObject));
    }
}
