using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private float _spawnTimer;
    private float _gameTimer;
    [SerializeField] private float _spawnTimerDuration = 2;
    [SerializeField] private float _gameTimerDuration = 10;

    public event Action GameEnded;
    public event Action GameStarted;
    public event Action ObjectSpawned;

    public int GameTime
    {
        get
        {
            return ((int)_gameTimer);
        }
    }

    void Start()
    {
        _spawnTimer = _spawnTimerDuration;
        _gameTimer = 0;
    }
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer < 0)
        {
            if (_gameTimer > 0)
            {
                ObjectSpawned?.Invoke();
            }
            _spawnTimer = _spawnTimerDuration;
        }
        if (_gameTimer < 0)
        {
            GameEnded?.Invoke();
            if (Input.GetKeyDown(KeyCode.R))
            {
                _gameTimer = _gameTimerDuration;
                GameStarted?.Invoke();
            }
        }
        else
        {
            _gameTimer -= Time.deltaTime;
        }
    }
    
}
