using System;
using UnityEngine;

public class GameSession : MonoBehaviour {
    public static event Action<int> OnScoreEvent;
    public static event Action<float> OnPlayedTimeEvent;

    private int _score;
    private float _playedTime;

    public void AddScore(int score) => _score += score;
    
    private void Update() {
        HandleEvents();
        _playedTime += Time.deltaTime;
    }

    private void HandleEvents() {
        if (OnScoreEvent != null)
            OnScoreEvent(_score);

        if (OnPlayedTimeEvent != null)
            OnPlayedTimeEvent(_playedTime);
    }
}