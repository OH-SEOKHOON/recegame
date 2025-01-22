using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameObject StartPanel;
    public GameObject EndPanel;
    public GameObject car;
    public GameObject road;
    public GameObject gas;

    public GameObject[] roads = new GameObject[8];
    public override void OnAwake()
    {
        base.OnAwake();
    }

    public void StartGame()
    {
        StartPanel.SetActive(false);
        SpawnRoad();
    }

    public void SpawnRoad()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i] = Instantiate(road, new Vector2(0, -4 + (i*2)), Quaternion.identity);
        }
        
        CheckArray();
    }
    
    void CheckArray()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            if (roads[i] == null)
            {
                Debug.LogError($"Road {i} is missing!");
            }
            else
            {
                Debug.Log($"Road {i} exists at position: {roads[i].transform.position}");
            }
        }
    }
}
