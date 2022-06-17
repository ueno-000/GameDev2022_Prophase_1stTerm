using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update    /// <summary> �̗� </summary>
    [SerializeField] public int _maxHp = 5;
    [SerializeField] public int _minHp = 0;

    [HideInInspector] public Slider hpSlider;
    void Start()
    {
        hpSlider = GetComponent<Slider>();
        //�X���C�_�[�̍ő�l�̐ݒ�
        hpSlider.maxValue = _maxHp;
    }

    /// <summary>Hp���X���C�_�[�ɕ\�������郁�\�b�h</summary>
    public  void UpdateSlider(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);
        hpSlider.value = hp;
    }
}
