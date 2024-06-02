using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterInfo : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void AddScore(int value = 0 , int damage = 0)
    {
        _score += value;
        if (damage !=0)
        {
            _score -= damage;
        }
        if (_score<=0)
        {
            _score = 0;
        }
        UpdateUI();
    }
    public int GetScore()
    {
        return _score;
    }
    private void UpdateUI()
    {
        _scoreText.text = "Score: " + _score.ToString();
    }
}
