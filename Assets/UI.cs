using System;
using UnityEngine;
using UnityEngine.UIElements;
public class UI : MonoBehaviour {
    private VisualElement _root;
    private Label _gameScore;
    private Label _playedTime;

    private void Awake() {
        _root = GetComponent<UIDocument>().rootVisualElement;
        _gameScore = _root.Q<Label>("GameScore");
        _playedTime = _root.Q<Label>("PlayedTime");
    }

    private void OnEnable() {
        GameSession.OnScoreEvent += Score;
        GameSession.OnPlayedTimeEvent += PlayedTime;
    }
    
    private void OnDisable() {
        GameSession.OnScoreEvent -= Score;
        GameSession.OnPlayedTimeEvent -= PlayedTime;
    }
    
    private void Score(int score) => _gameScore.text = score.ToString();

    private void PlayedTime(float playedTime) {
        var roundedTime = Math.Round(playedTime, 2);
        _playedTime.text = roundedTime.ToString();
    }
}
