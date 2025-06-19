using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    [SerializeField]
    TMP_Text _textScore;

   int _score = 0;

    public void IncreaseScore()
    {
        _score++;
        _textScore.text = _score.ToString();
    }
 
}
