using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovment : MonoBehaviour {
    public float Speed;
    public float RotationSpeed;
    public GameObject[] bodyObject =new GameObject[0];

    public float Zoffset = -0.5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up  * RotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * RotationSpeed * Time.deltaTime);
        }
    }
}
