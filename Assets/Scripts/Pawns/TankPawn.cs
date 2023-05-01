using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();

    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, 5);
    }
    public override void MoveBackward()
    {
        mover.Move(transform.forward, -5);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(360);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-360);
    }

    public override void RotateUp()
    {
        mover.RotateX(90);


    }

    public override void RotateDown()
    {
        mover.RotateX(-90);
    }

    public override void Shoot()
    {
        shooter.Shoot(Bullet, fireForce, damageDone, shellLifespan);
    }

    public override void RotateTowards(Vector3 targetPosition)
    {
        // Find the vector to our target
        Vector3 vectorToTarget = targetPosition - transform.position;
        // Find the rotation to look down that vector
        Quaternion targetRotation = Quaternion.LookRotation(vectorToTarget, Vector3.up);
        // Rotate closer to that vector, but don't rotate more than our turn speed allows in one frame
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }
}
