using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 vel;
    float _speed = 15f;
    void Start()
    {
        vel = Vector3.zero - transform.position;
        vel.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        // have it move towards 0,0,0
        transform.position += vel*Time.deltaTime*_speed;
    }
}
