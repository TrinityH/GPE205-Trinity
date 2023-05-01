using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{

    private Rigidbody rb;
    // Start is called before the first frame update
    public override void Start()
    {
        //Get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    public override void Move(Vector3 direction, float speed)
    {
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + moveVector);
    }

    public override void Rotate(float rotateSpeed)
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    public override void RotateX(float rotateXSpeed)
    {
        transform.Rotate(rotateXSpeed * Time.deltaTime, 0, 0);
    }

    private void LateUpdate()
    {
        {
           // float clampedAngle = Mathf.Clamp(gun.transform.localEulerAngles.x, -20, 50);
            // if you want to clamp on X-Axis
           // gun.transform.localEulerAngles = new Vector3(clampedAngle, 0, 0);
        }
    }
}
