using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValueScript : MonoBehaviour,IGetValue,IReceiveDamage
{
    /// <summary>
    /// �f�o�b�O���[�hTrue�ɂ���ƍU�����󂯂Ȃ�
    /// </summary>
    [Header("�y�f�o�b�O�p�z�F?������ƍU�����󂯂Ȃ�"), SerializeField] bool _debugMode = false;

    /// <summary> HitPoint </summary>
    [Header("�̗�"),SerializeField] int _hp = 100;
    int _maxHp;
    [SerializeField] GameObject HPController;
    [SerializeField] HealthController helth;

    /// <summary>�񕜗�</summary>
    [Header("�񕜗�"), SerializeField] int _resilienceValue = 0;

    /// <summary>EXP</summary>
    [Header("�o���l"),SerializeField] int _exp = 0;

    /// <summary> MoveSpeed</summary>
    [Header("�ړ����x"), SerializeField] float _speed = 5f;

    /// <summary>DefensePower</summary>
    [Header("�h���"), SerializeField] float _defensePower = 5f;

    [HideInInspector]public bool isGameOver = false;

    public int Hp
    {
        set
        {
            _hp = Mathf.Clamp(value, 0, _maxHp);
        }
        get
        {
            return _hp;
        }
    }


    void Start()
    {
        _maxHp = HPController.GetComponent<HealthController>()._maxHp;
        helth = helth.GetComponent<HealthController>();

    }

    // Update is called once per frame
    void Update()
    {
        //hp����
        helth.UpdateSlider(_hp);
        if (_hp <= 0&& isGameOver == false)
        {
            isGameOver = true;
            Debug.Log("GameOver");
        }
    }
    /// <summary>
    /// EXP���Z����
    /// </summary>
    /// <param name="getexp"></param>
    public void GetEXP(int getexp)
    {
        _exp += getexp;
    }

    /// <summary>
    /// �_���[�W����
    /// </summary>
    /// <param name="damage"></param>
    public void ReceiveDamage(int damage)
    {
        if (isGameOver == false && _debugMode == false)
        {
            _hp -= damage;
            Debug.Log("add: " + damage + "hp: " + _hp);
        }
    }
}
