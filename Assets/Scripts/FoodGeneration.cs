using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGeneration : MonoBehaviour {
    public float XSize = 9f;
    public float ZSize = -19f;

    public GameObject foodPrefab;

    public Vector3 curPos;

    public GameObject curFood;


	// Use this for initialization
	void Start () {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
		
	}
	
    void RandomPos()
    {
        curPos = new Vector3(Random.Range(XSize, -XSize), 12.16f, Random.Range(ZSize, -1f));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
