using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public string type;
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (type == "start")
        {
            gameController.StartNewGame();
        }

        if (type == "end")
        {
            gameController.EndGame();
        }
    }
}
