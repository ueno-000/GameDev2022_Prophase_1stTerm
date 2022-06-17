using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreManger : MonoBehaviour
{
    [SerializeField] Text _timeText;
    [SerializeField] Text _judgeText;
    float _score;

    void Start()
    {
           _score = GameManager._survivalTime;

        _timeText.text = _score.ToString("f1");

        if (!GameManager.isGameOver)
        {
            _judgeText.text = "無事救出されました！！";
        }
        else
        {
            _judgeText.text = "助けが来る前に力尽きました";
        }
    }


}
