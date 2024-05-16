using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Controller : MonoBehaviour
{

    public Pawn pawn;
    public float score;
    // Start is called before the first frame update
    public virtual void Start()
    {

    }

    // Update is called once per frame
    public virtual void Update()
    {

    }

    public virtual void ProcessInputs()
    {

    }

    public virtual void ChangeState()
    {

    }

    public virtual void Seek()
    {

    }

    public virtual void SeekState()
    {

    }

    public virtual void MakeDecisions()
    {

    }

    public virtual void AddToScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    
}
