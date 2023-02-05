using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int _score = 0;
    private TMP_Text _text;
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        Enemy.onChangeScore += ChangeScore;
        Player.onChangeScore += ChangeScore;
    }

    private void ChangeScore(int score)
    {
        if (_score + score < 0)
        {
            _score = 0;
        }
        else
        {
            _score += score;
        }
        ChangeScoreUI();
    }
    private void ChangeScoreUI()
    {
        _text.text = _score.ToString();
    }

    private void OnDisable()
    {
        Enemy.onChangeScore -= ChangeScore;
        Player.onChangeScore -= ChangeScore;
    }
}
