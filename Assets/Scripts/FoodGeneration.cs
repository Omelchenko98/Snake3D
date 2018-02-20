using UnityEngine;
using System.Collections;

public class FoodGeneration : MonoBehaviour
{
    // Doesn't good idea to keep it public
    // Better to create property(Read about it) or get/set functions for change it 
    public float XSize = 8.8f;
    public float ZSize = 8.8f;
    public GameObject foodPrefab;
    public Vector3 curPos;
    public GameObject curFood;
    
    // Good enough, but can be better if we would have a posibility to create different food
    void AddNewFood()
    {
        RandomPos();
        curFood = GameObject.Instantiate(foodPrefab, curPos, Quaternion.identity) as GameObject;
    }
    void RandomPos()
    {
        // XSize*-1 == -Xsize;
        // 0.25f magic number; create a variable
        // and Random.Range, better to store it return value to local variable and use after it
        curPos = new Vector3(Random.Range(XSize * -1, XSize), 0.25f, Random.Range(ZSize * -1, ZSize));
    }

    // For current version good
    // But for this issue "else { return;}" unnesesary
    // and you can use principle of early return
    // if(currentFood != null) return;
    //
    // AddNewFood();
    void Update()
    {
        if (!curFood)
        {
            AddNewFood();
        }
        else
        {
            return;
        }
    }
}
