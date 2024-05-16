using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankPawn : Pawn
{
    private float nextEventTime;
    private float timerDelay;
    // Start is called before the first frame update
    public override void Start()
    {
        //healthbar = GetComponentInChildren<Image>();

        float secondsPerShot;

        if(fireRate <= 0)
        {
            secondsPerShot = Mathf.Infinity;
        }
        else
        {
            secondsPerShot = 1 / fireRate;
        }

        timerDelay = secondsPerShot;
        nextEventTime = Time.time + timerDelay;

        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Start();

    }

    public override void MoveForward()
    {
        mover.Move(transform.forward, moveSpeed);
    }
    public override void MoveBackward()
    {
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void RotateClockwise()
    {
        mover.Rotate(turnSpeed);
    }

    public override void RotateCounterClockwise()
    {
        mover.Rotate(-turnSpeed);
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
        if(Time.time >= nextEventTime)
        {
            shooter.Shoot(Bullet, fireForce, damageDone, shellLifespan);
            nextEventTime = Time.time + timerDelay;
            cannon = GetComponent<AudioSource>();
            cannon.Play();
        }
        
    }


    public override void Boost()
    {
        moveSpeed += boostSpeed;
    }

    public override void NoBoost()
    {
        moveSpeed -= boostSpeed;
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

    public override void MakeNoise()
    {
        if (noiseMaker != null)
        {
            noiseMaker.volumeDistance = noiseMakerVolume;
        }
    }

    public override void StopNoise()
    {
        
            noiseMaker.volumeDistance = 0;
        
    }
}
