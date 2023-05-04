using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MoleScript : MonoBehaviour
{

    private float max_time_until_move_up = 5f;
    private float max_time_until_move_down = 3f;

    private bool up = false;
    
    private float time_until_move_up;
    private float time_until_move_down;

    public GameController gameController;

    void Start()
    {
        
    }
    
    void Update()
    {
        float time_delta = Time.deltaTime;
        
        if (up)
        {
            time_until_move_down -= time_delta;
            
            if (time_until_move_down <= 0) MoveDown();
        }
        else
        {
            time_until_move_up -= time_delta;
            
            if (time_until_move_up <= 0) MoveUp();
        }
    }

    public void InitMovement()
    {
        GenerateTimeUntilMoveUp();
    }

    private void GenerateTimeUntilMoveUp()
    {
        time_until_move_up = Random.value * (max_time_until_move_up + 1f) - 1f;
    }

    private void MoveUp()
    {
        gameObject.GetComponent<Animator>().SetTrigger("up");
        gameObject.GetComponent<Animator>().ResetTrigger("down");
        gameObject.GetComponent<Animator>().ResetTrigger("hit");

        up = true;
        GenerateTimeUntilMoveDown();
    }
    
    private void GenerateTimeUntilMoveDown()
    {
        time_until_move_down = Random.value * (max_time_until_move_down + 1f) - 1f;
    }
    
    private void MoveDown()
    {
        gameObject.GetComponent<Animator>().SetTrigger("down");
        gameObject.GetComponent<Animator>().ResetTrigger("up");
        gameObject.GetComponent<Animator>().ResetTrigger("hit");

        up = false;
        GenerateTimeUntilMoveUp();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hammer")
        {
            gameController.AddPoint();
            
            gameObject.GetComponent<Animator>().SetTrigger("hit");
            gameObject.GetComponent<Animator>().ResetTrigger("up");
            gameObject.GetComponent<Animator>().ResetTrigger("down");
        }
    }
}
