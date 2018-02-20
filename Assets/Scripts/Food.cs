using UnityEngine;
using System.Collections;

// Firstly I thinks we have no nesesary to inherit from MonoBehaviour
// Better to create simple class Food, where storage all data about it, position, point etc.
// But anyway we need to have a FoodView class, which would display this info at game scene.
// I'll explain this principle at the lesson
public class Food : MonoBehaviour
{

    // Look in snakeMovement class
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeMain"))
        {
            other.GetComponent<SnakeMovment>().AddTail();
            Destroy(gameObject);
        }
    }

}
