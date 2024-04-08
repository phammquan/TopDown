using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] Text _scoretext;
    void Start()
    {
        Obsever.Instance.AddListener("ScoreChange", SetScoreText);
    }

    void Update()
    {
    }

    public void SetScoreText(object score)
    {
        _scoretext.text = "Score: " + score.ToString()
        + "\n" + "HighScore: " + GameManager.Instance.Hightscore.ToString();
    }
}
