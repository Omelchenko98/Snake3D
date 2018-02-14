using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SnakeMain"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}