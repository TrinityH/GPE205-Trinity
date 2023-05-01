using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{

  
    public abstract void Shoot(GameObject Bullet, float fireForce, float damageDone, float lifespan);

    // Start is called before the first frame update
    public abstract void Start();

    // Update is called once per frame
    public abstract void Update();
 
}
