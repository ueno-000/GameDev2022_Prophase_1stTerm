using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPController : MonoBehaviour
{
    [SerializeField]public int _exp = 0;
  //  [SerializeField] int _pulsexp = 10;
    [SerializeField] int[] _maxEXP = new [] {100,200,300,400 };

    [SerializeField] int _level = 1;
    int nowLevel = 0;

    [HideInInspector] public Slider slider;
    Text _text;
    [SerializeField] GameObject _levelText;

    [Header("���݂̃��x���̌o���l�̏��"), SerializeField] public int _maxNowLevelExp;

    [SerializeField] PlayerValueScript _playerValueScript;
    void Start()
    {
        slider = GetComponent<Slider>();
        _text = _levelText.GetComponent<Text>();
        //_maxEXP[0] = GetComponent<HealthController>()._maxHp;
        nowLevel = 0;
        slider.maxValue = _maxEXP[0];
        _maxNowLevelExp = _maxEXP[0];
       
    }

    void Update()
    {
        _exp = _playerValueScript.GetComponent<PlayerValueScript>()._exp;
        UpdateSlider(_exp);
        UPLevel();
    }
    /// <summary>Hp���X���C�_�[�ɕ\�������郁�\�b�h</summary>
    public void UpdateSlider(int exp)
    {
        exp = Mathf.Clamp(exp, 0, _maxEXP[nowLevel]);
        slider.value = exp;
    }

    public void UPLevel()
    {
        if (_exp >= _maxEXP[nowLevel])
        {
            nowLevel++;
            _exp = 0;
            _level++;
            _text.text = _level.ToString();
            slider.maxValue = _maxEXP[nowLevel];
            _maxNowLevelExp = _maxEXP[nowLevel];

        }
    }
}
