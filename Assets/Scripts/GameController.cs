using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public GameObject molePrefab;
    public TMP_Text timerText;
    public TMP_Text pointsText;
    public GameObject[] molesSpawnPoints;

    private float time;
    private int points;
    private GameObject[] moles;
    private bool playing = false;
    
    void Start()
    {
        StartNewGame();
    }

    void Update()
    {
        if (playing)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                EndGame();
            }
            
            DrawTime();
        }
    }

    public void StartNewGame()
    {
        time = 30f;
        points = 0;
        playing = true;

        InstantiateMoles();
    }

    public void EndGame()
    {
        playing = false;
        DestroyMoles();
    }

    private void DrawTime()
    {
        timerText.SetText("0:" + Mathf.RoundToInt(time));
    }

    private void ResetPoints()
    {
        points = 0;

        DrawPoints();
    }

    public void AddPoint()
    {
        points++;

        DrawPoints();
    }

    private void DrawPoints()
    {
        pointsText.SetText(points.ToString());
    }

    private void InstantiateMoles()
    {
        moles = new GameObject[molesSpawnPoints.Length];

        for (int i = 0; i <= molesSpawnPoints.Length - 1; i++)
        {
            moles[i] = Instantiate(molePrefab, molesSpawnPoints[i].transform.position, molePrefab.transform.rotation, molesSpawnPoints[i].transform);
            moles[i].GetComponent<MoleScript>().InitMovement();
            moles[i].GetComponent<MoleScript>().gameController = this;
        }
    }

    private void DestroyMoles()
    {
        for (int i = 0; i <= moles.Length - 1; i++)
        {
            Destroy(moles[i]);
        }
    }

}
