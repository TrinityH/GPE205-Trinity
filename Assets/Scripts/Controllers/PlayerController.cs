using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode rotateUpKey;
    public KeyCode rotateDownKey;

    // Start is called before the first frame update
    public override void Start()
    {
        //Run the start function from the parent(base) class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Process our keyboard inputs
        ProcessInputs();
        //Run the update function from the parent(base) class
        base.Update();
    }

    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
        }

        if(Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
        }

        if(Input.GetKey(rotateUpKey))
        {
            pawn.RotateUp();
        }

        if(Input.GetKey(rotateDownKey))
        {
            pawn.RotateDown();
        }

    }
}
