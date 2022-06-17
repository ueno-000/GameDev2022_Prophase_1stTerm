using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValueScript : AudioBase, IGetValue,IReceiveDamage
{
    /// <summary>
    /// �f�o�b�O���[�hTrue�ɂ���ƍU�����󂯂Ȃ�
    /// </summary>
    [Header("�y�f�o�b�O�p�z�F?������ƍU�����󂯂Ȃ�"), SerializeField] public bool _debugMode = false;

    /// <summary> HitPoint </summary>
    [Header("�̗�"),SerializeField] int _hp = 100;
    int _maxHp;
    [SerializeField] HealthController helth;

    /// <summary>�񕜗�</summary>
    [Header("�񕜗�"), SerializeField] int _resilienceValue = 0;

    /// <summary>EXP</summary>
    [Header("�o���l"),SerializeField] public int _exp = 0;
    int _nowExp;
    [SerializeField] EXPController expcontroller; 

    /// <summary> MoveSpeed</summary>
    [Header("�ړ����x"), SerializeField] float _speed = 5f;

    /// <summary>DefensePower</summary>
    [Header("�h���"), SerializeField] float _defensePower = 5f;

    [HideInInspector] static public bool isGameOver = false;

    [Header("�_���[�W���󂯂����̃T�E���h"),SerializeField] AudioClip _damageSound;

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

    private void Awake()
    {
        _hp += PlayerSpawnScript._hp; 
    }
    void Start()
    {
        isGameOver = false;
        helth = helth.GetComponent<HealthController>();
        helth.gameObject.GetComponent<HealthController>()._maxHp = _hp;
       // _nowExp = expcontroller.gameObject.GetComponent<EXPController>()._exp;
        expcontroller = expcontroller.GetComponent<EXPController>();
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
            Play(_damageSound,0.5f);
        }
    }

    public void Recovery()
    {
        _hp += 50;
    }
}
