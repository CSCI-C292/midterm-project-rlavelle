using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Camera cam;
    private float _speed = 0.5f;
    private Vector3 dir;
    private float _turnSensitivity = 200f; 
    float _distance = 31.0f;
    // Start is called before the first frame update
    void Start()
    {
        SetupCam();
    }

    // Update is called once per frame
    void Update()
    {
        // rotate left
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(-Vector3.up*_turnSensitivity*Time.deltaTime);
        }
        // rotate right
        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(Vector3.up*_turnSensitivity*Time.deltaTime);
        }

        Move();

        _speed += 0.03f*Time.deltaTime;
    }

    void Move(){
        transform.RotateAround(Vector3.zero, transform.forward*Time.deltaTime, _speed);
        cam.transform.RotateAround(Vector3.zero, transform.forward*Time.deltaTime, _speed);
    }

    void SetupCam(){
        cam = Camera.main;
        Vector3 dir = new Vector3(0,0,-_distance);
        cam.transform.position = transform.position + dir;
        cam.transform.LookAt(transform);
    }

    void OnTriggerEnter(Collider collider){
        if(collider.name == "Crater(Clone)" || collider.name == "Asteroid(Clone)"){
            GameState.Instance.InitiateGameOver();
            Destroy(gameObject);
        }
    }
}
