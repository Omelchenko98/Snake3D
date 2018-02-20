using UnityEngine;
using System.Collections;

public class TailMovment : MonoBehaviour
{

    public float Speed;
    public Vector3 tailTarget;
    public int indx;        //Unnesesary varialbe see below
    public GameObject tailTargetObj;
    public SnakeMovment mainSnake;
    void Start()
    {

        mainSnake = GameObject.FindGameObjectWithTag("SnakeMain").GetComponent<SnakeMovment>();
        // Magic numbers aren't good style, make it by multiplying on a variable 
        // 2.5f should be a variable like float speedMultiplier
        // And one more thing. What would you do if snake speed change? Look for Observer pattern 
        Speed = mainSnake.Speed + 2.5f;
        // Actually not the best solution. I've understood what you want to do, but we can write a function GetTailTarget() or 
        // smth similar. And I don't get why you get link to the snake head. As for me, better to get link to the last tail obj
        // and move toward it
        tailTargetObj = mainSnake.tailObjects[mainSnake.tailObjects.Count - 2];
        indx = mainSnake.tailObjects.IndexOf(gameObject);
    }
    void Update()
    {
        tailTarget = tailTargetObj.transform.position;
        transform.LookAt(tailTarget);
        transform.position = Vector3.Lerp(transform.position, tailTarget, Time.deltaTime * Speed);
    }
    
    // It'd be better if we check collision only in the head.
    // Firstly hole colision logic in the one class
    // Secondly why snake body should know enything about head?
    // Maybe we should to delete our tail after colision, but it's better to do as a public function smth like void DestroyTail()
    // Anyway this code isn't nesesary
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("SnakeMain"))
        {
            if (indx > 2)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

    }

}
