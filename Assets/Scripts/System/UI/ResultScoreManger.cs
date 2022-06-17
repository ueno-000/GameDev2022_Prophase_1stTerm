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
            _judgeText.text = "�����~�o����܂����I�I";
        }
        else
        {
            _judgeText.text = "����������O�ɗ͐s���܂���";
        }
    }


}
