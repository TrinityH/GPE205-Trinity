using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Bounce : MonoBehaviour
{
    float speed = 5f;
    float height = 0.5f;
    Vector3 pos;
    private void Start()
    {
        pos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //Calculate the new Y position
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        transform.position = (new Vector3(transform.position.x, newY, transform.position.z));
    }
}
