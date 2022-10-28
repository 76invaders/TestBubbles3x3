using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textMesh;

    void Start()
    {
        _textMesh.text = $"Points: {Score.score}";
    }

    public void RecivePoints(int points)
    {
        Score.score += points;
        _textMesh.text = $"Points: {Score.score}";
    }
}