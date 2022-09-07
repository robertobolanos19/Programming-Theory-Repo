using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punkBehavior : CharacterBehavior
{
    [SerializeField] float punkSpeed;
    [SerializeField] float punkJumpPower;

    //POLYMORPHISM
    protected override void Start()
    {
        gameManager = GameManager.instance;

        JumpPower = punkJumpPower;
        Speed = punkSpeed;
    }
    //POLYMORPHISM
    protected override void Update()
    {
        base.Update();
    }
    //POLYMORPHISM
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    //POLYMORPHISM
    protected override void HandleMovement()
    {
        base.HandleMovement();
    }
    //POLYMORPHISM
    protected override void HandleJump()
    {
        base.HandleJump();
    }
    //POLYMORPHISM
    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
    //POLYMORPHISM
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
