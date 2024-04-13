using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;
    public int score
    {
        get 
        {
            return _score;
        }
        set
        {
            _score = value;
            _scoreText.text = "Score \n" + _score;
        }
    }

    [SerializeField] private TextMeshProUGUI _startAgainText;

    private TimeManager _timeManager;


    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManager>();
        _timeManager.GameEnded += OnGameEnd;
        _timeManager.GameStarted += OnGameStart;
        score = 0;
    }


    public void OnGameEnd()
    {
        _startAgainText.enabled = true;
    }

    public void OnGameStart()
    {
        score = 0;
        _startAgainText.enabled = false;
    }

    public void IncreaseScore(Item item)
    {
        score += item.itemInfo.score;
    }

    private void Update()
    {
        _timerText.text = _timeManager.GameTime.ToString();
    }
}
