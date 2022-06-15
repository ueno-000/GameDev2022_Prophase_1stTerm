using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreManger : MonoBehaviour
{
    [SerializeField] Text _timeText;

    float _score;

    void Start()
    {
           _score = GameManager._survivalTime;

        _timeText.text = _score.ToString("f1");
    }


}
