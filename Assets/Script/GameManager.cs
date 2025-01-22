using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : Singleton<GameManager>
{
    public GameObject StartPanel;
    public GameObject GamePanel;
    public GameObject EndPanel;
    
    public GameObject car;
    public GameObject road;
    public GameObject gas;

    private GameObject[] roads = new GameObject[8];
    private float roadSpeed = 2f;

    private GameObject player;
    
    private GameObject jerrycan;
    public float energy;
    private float nextDecreaseTime = 0f;
    private float nextinstanceTime = 0f;

    
    public override void OnAwake()
    {
        base.OnAwake();
    }

    public void StartGame()
    {
        StartPanel.SetActive(false);
        GamePanel.SetActive(true);
        SpawnRoad();
        SpawnCar();
        energy = 100f;
    }

    public void SpawnRoad()
    {
        for (int i = 0; i < roads.Length; i++)
        {
            roads[i] = Instantiate(road, new Vector2(0, -4 + (i * 2)), Quaternion.identity);
        }
    }

    void SpawnCar()
    {
        player = Instantiate(car, new Vector2(0, -3), Quaternion.identity);
        SpriteRenderer renderer = player.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
    }

    void SpawnGas()
    {
        jerrycan = Instantiate(gas, new Vector2(Random.Range(-2, 3), 8), Quaternion.identity);
        SpriteRenderer renderer = jerrycan.GetComponent<SpriteRenderer>();
        renderer.sortingOrder = 1;
    }


    private void Update()
    {
        MoveRoad();
        CheckGas();
    }

    public void MoveRoad()
    {
        if (player != null)
        {
            for (int i = 0; i < roads.Length; i++)
            {
                // 도로를 아래로 이동
                roads[i].transform.position += Vector3.down * roadSpeed * Time.deltaTime;

                // y 위치가 -8 이하로 내려가면 위치를 재배치
                if (roads[i].transform.position.y <= -8)
                {
                    roads[i].transform.position = new Vector2(0, 8);
                }
            }
        }
    }

    public void RightCar()
    {
        if (player.transform.position.x < 2)
        {
            player.transform.position += (Vector3.right * roadSpeed * Time.deltaTime);
        }
    }
    
    public void LeftCar()
    {
        if (player.transform.position.x > -2)
        {
            player.transform.position += (-Vector3.right * roadSpeed * Time.deltaTime);
        }
    }

    public void CheckGas()
    {
        if (player != null)
        {
            if (Time.time >= nextDecreaseTime)
            {
                // 값 감소
                energy -= 10f;
                Debug.Log("Current Value: " + energy);

                // 다음 감소 시간 설정
                nextDecreaseTime = Time.time + 1f;
            }
            
            int randomInt = Random.Range(1, 11);
        
            if (Time.time >= nextinstanceTime)
            {
                // 가스생성
                if (randomInt < 7)
                {
                    SpawnGas();
                    Debug.Log("가스생성완료");
                }

                // 다음 감소 시간 설정
                nextinstanceTime = Time.time + 2f;
            }
        }
    }
}
