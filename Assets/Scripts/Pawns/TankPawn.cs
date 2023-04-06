using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class TankPawn : Pawn
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
}
