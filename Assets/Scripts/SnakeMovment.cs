using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class SnakeMovment : MonoBehaviour
{
    // About variables
    // if it's local it should to start from small letter and each new word from big one.
    // Like there speed; rotationSpeed;
    // And public variables aren't good. Read about [SerialezedField].
    public float Speed;
    public float RotationSpeed;
    // I can't say it's bad, but would be better if we collect List<Tail> tails = ***;
    // Cuz in currect situation if we want to get Tail component we should call GetComponent<Tail>();
    // What is "hard" operation and we cant know does it has this component, so we cat get null object and error in future
    // And one more thing. From tail component we can get gameObject and transform more simple than from gameObject get tail.
    // I'll explain it on the lesson
    public List<GameObject> tailObjects = new List<GameObject>();
    public float z_offset = 0.5f;

    public GameObject TailPrefab;
    // Better to store all UI in UIController
    public Text ScoreText;
    public int score = 0;
    void Start()
    {
        tailObjects.Add(gameObject);
    }
    void Update()
    {
        // Bad logic to controll UI in the logic scripts. Better to create class UIController where write public function
        // public IncreaseScores
        // public ShowMenuScreen
        // public ShowGameOverScreen
        // etc. it's not the best solution but for now it's good enough
        
        // so there will be smth like this
        // UIController.IncreaseScores(1);
        // we send the parameter cuz if we eat we the common food we would add 5 points but if some rare food it'd 10 points for instance
        // But any way the code abowe should calls if collision logic. And the code below became unnesesary.
        ScoreText.text = score.ToString();
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        // Create function the TurnRight() and call it there.
        // More clear code. If we decide to add AI logic we won't to change logic, just call these functions
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);
        }
        // The same but TurnLeft()
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -1 * RotationSpeed * Time.deltaTime);
        }
    }
// Add colision logic
// private void OnTriggerEnter(Collider other)
//{
    // There we should to detect type of colision
    // "switch" of "if-else" doesn't matter
    // where if it's a food call function EatFood(Food food);
    // if it's tail call function EatTail(Tile tile);
    // etc.
    // If it's difficult for you we'll get a look at it on the lesson, just tell me
//}

// public EatFood(Food food)
//{
    // I'll write a prototype of function. You can improve it.
    //
    // UIController.IncreaseScores(food.points);
    // AddTail(food.points * foodMultiplier); // this for issue if we'll create a different food
                                              // which will add more than one tail for once
                                              
    // Maybe more logic but for now it's enough
//}
    public void AddTail()
    {
        score++;
        // Create the public function GameObject GetTailObj();
        // Cuz this isn't good style
        Vector3 newTailPos = tailObjects[tailObjects.Count - 1].transform.position;
        newTailPos.z -= z_offset;
        tailObjects.Add(GameObject.Instantiate(TailPrefab, newTailPos, Quaternion.identity) as GameObject);
    }
}
