using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreUI;
    [SerializeField] private ShipInteracterObservable _shipInteracter;
    private int _score = 0;
    private int _scoreMultiplier = 1;

    public int GetScore()
    {
        return _score;

    }

    private void UpdateScore(Box box, Ship ship, Successfulness successfulness)
    {
        int points = Mathf.RoundToInt((box.GetSize() / ship.GetSize()) * 10);
        AddScore(points);
        //UpdateScoreMultiplier(successfulness);
        _scoreUI.text = _score.ToString();
    }

    private void UpdateScoreMultiplier(Successfulness successfulness)
    {
        switch (successfulness)
        {
            case Successfulness.Perfect:
                _scoreMultiplier += 2;
                break;
            case Successfulness.Good:
                _scoreMultiplier += 1;
                break;
            case Successfulness.Satisfied:
                _scoreMultiplier = 1;
                break;
        }
    }

    private void AddScore(int points)
    {
        _score += Mathf.RoundToInt(points *= _scoreMultiplier);
    }

    private void OnEnable()
    {
        _shipInteracter.OnLanded += UpdateScore;
    }

    private void OnDisable()
    {
        _shipInteracter.OnLanded -= UpdateScore;
    }
}
