using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public Mover mover;
    // Start is called before the first frame update
    public virtual void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    // Variable for our shell prefab
    public GameObject Bullet;
    // Variable for our firing force
    public float fireForce;
    // Variable for our damage done
    public float damageDone;
    // Variable for how long our bullets survive if they don't collide
    public float shellLifespan;

    //Variable for GameObject Shooter
    public Shooter shooter;
    //Functions for Movement
    public abstract void MoveForward();
    public abstract void MoveBackward();
    public abstract void RotateClockwise();

    public abstract void RotateCounterClockwise();

    public abstract void RotateUp();

    public abstract void RotateDown();

    //Function for Shooting
    public abstract void Shoot();

    public abstract void RotateTowards(Vector3 targetPosition);
}
