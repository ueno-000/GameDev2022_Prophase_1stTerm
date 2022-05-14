using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPtest : MonoBehaviour
{
    [SerializeField] int _exp = 0;
    [SerializeField] int _pulsexp = 10;
    [SerializeField] int[] _maxEXP = new [] {100,200,300,400 };

    [SerializeField] int _level = 1;
    int nowLevel = 0;

    [HideInInspector] public Slider slider;
    Text text;
    [SerializeField] GameObject _levelText;

    void Start()
    {
        slider = GetComponent<Slider>();
        text = _levelText.GetComponent<Text>();
        //_maxEXP[0] = GetComponent<HealthController>()._maxHp;
        nowLevel = 0;
        slider.maxValue = _maxEXP[0];
    }
    void Update()
    {
        UpdateSlider(_exp);
        UPLevel();
    }
    /// <summary>Hpをスライダーに表示させるメソッド</summary>
    public void UpdateSlider(int exp)
    {
        exp = Mathf.Clamp(exp, 0, _maxEXP[nowLevel]);
        slider.value = exp;
    }

    public void UPEXP()
    {
        _exp += _pulsexp;
        Debug.Log("EXP:"+_exp+"Level:"+_level);
    }

    public void UPLevel()
    {
        if (_exp >= _maxEXP[nowLevel])
        {
            nowLevel++;
            _exp = 0;
            //HealthController.GetComponent<HealthController>()._maxHp = _maxEXP[nowLevel];
            slider.maxValue = _maxEXP[nowLevel];
            _level++;
        }
    }
}
