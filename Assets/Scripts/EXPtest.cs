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

    [SerializeField] GameObject HealthController;
    [SerializeField] HealthController helth;

    void Start()
    {
        _maxEXP[0] = HealthController.GetComponent<HealthController>()._maxHp;
        helth = helth.GetComponent<HealthController>();
        nowLevel = 0;
    }
    void Update()
    {
        //hpˆ—
        helth.UpdateSlider(_exp);

        UPLevel();
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
            _maxEXP[nowLevel+1] = HealthController.GetComponent<HealthController>()._maxHp;
            _level++;
        }
    }
}
