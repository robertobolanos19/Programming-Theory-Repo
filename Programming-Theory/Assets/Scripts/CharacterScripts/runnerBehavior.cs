using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerBehavior : CharacterBehavior
{
    [SerializeField] float runnerSpeed;
    [SerializeField] float runnerJumpPower;

    protected override void Start()
    {
        gameManager = GameManager.instance;

        JumpPower = runnerJumpPower;
        Speed = runnerSpeed;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void HandleMovement()
    {
        base.HandleMovement();
    }

    protected override void HandleJump()
    {
        base.HandleJump();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
