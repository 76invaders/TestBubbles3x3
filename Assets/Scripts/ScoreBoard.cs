using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI _textMesh;
    int _score = 0;

    void Start()
    {
        _textMesh.text = $"Points: {_score}";
    }

    public void RecivePoints(int points)
    {
        _score += points;
        _textMesh.text = $"Points: {_score}";
    }

    public void ResetPoints()
    {
        _score = 0;
    }
}
