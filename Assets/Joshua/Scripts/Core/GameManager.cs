﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private int currentRoom = 0;
    [SerializeField] private int maxRooms = 10;
    [SerializeField] private List<GameObject> roomPrefabs;
    [SerializeField] private string gameSceneName;

    public void SelectRoom()
    {
        Instantiate(roomPrefabs[Random.Range(0, roomPrefabs.Count)]);
    }

    public void EnterNewRoom()
    {
        if(currentRoom >= maxRooms)
        {
            Victory();
        }
        else
        {
            currentRoom++;
            SceneManager.LoadScene(gameSceneName);
        }
    }

    public void StartAgain()
    {
        currentRoom = 0;
        SceneManager.LoadScene(gameSceneName);
    }

    private void Victory()
    {

    }
}
