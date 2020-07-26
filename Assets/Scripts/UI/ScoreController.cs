using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreObject;

    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            if (_score != value)
            {
                _score = value;
                if (scoreObject != null) scoreObject.text = _score.ToString();
            }
        }
    }

    public void UpdateScore()
    {
        score++;
    }
}
