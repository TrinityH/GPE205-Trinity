
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerController : Controller
{
    public KeyCode shootKey;
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    public KeyCode rotateClockwiseKey;
    public KeyCode rotateCounterClockwiseKey;
    public KeyCode rotateUpKey;
    public KeyCode rotateDownKey;
    public KeyCode boost;
    public float score;
    public float lives;
    // List that holds our players
    public List<PlayerController> players;

    // Start is called before the first frame update
    public override void Start()
    {
        //If we have a GameManager
        if (GameManager.instance != null)
        {
            //And it tracks the players
            if (GameManager.instance.players != null)
            {
                //Register with the GameManager
                GameManager.instance.players.Add(this);
            }
        }

        score = 0;
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

    public override void AddToScore()
    {
        score += 100;
    }
    public override void ProcessInputs()
    {
        if (Input.GetKey(moveForwardKey))
        {
            pawn.MoveForward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.MoveBackward();
            pawn.MakeNoise();
        }

        if (Input.GetKey(rotateClockwiseKey))
        {
            pawn.RotateClockwise();
            pawn.MakeNoise();
        }

        if(Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.RotateCounterClockwise();
            pawn.MakeNoise();
        }

        if(Input.GetKey(rotateUpKey))
        {
            pawn.RotateUp();
            pawn.MakeNoise();
        }

        if(Input.GetKey(rotateDownKey))
        {
            pawn.RotateDown();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(shootKey))
        {
            pawn.Shoot();
            pawn.MakeNoise();
        }

        if (Input.GetKeyDown(boost))
        {
            pawn.Boost();
            pawn.MakeNoise();
        }

        if (Input.GetKeyUp(boost))
        {
            pawn.NoBoost();
        }

        if(!Input.GetKey(moveForwardKey) && !Input.GetKey(moveBackwardKey) && !Input.GetKey(shootKey) && !Input.GetKey(rotateClockwiseKey) && !Input.GetKey(rotateCounterClockwiseKey))
        {
            pawn.StopNoise();
        }

    }

    public void OnDestroy()
    {
        //If we have a GameManager
        if (GameManager.instance != null)
        {
            // And it tracks the players
            if(GameManager.instance.players != null)
            {
                // Deregister with the GameManager
                GameManager.instance.players.Remove(this);
            }
        }
    }
}
