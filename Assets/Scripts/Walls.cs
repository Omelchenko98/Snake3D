using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour
{
    // The same issue with snakeBody
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SnakeMain"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

    }
}
