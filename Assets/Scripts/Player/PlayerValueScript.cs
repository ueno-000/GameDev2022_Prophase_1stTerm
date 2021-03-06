using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValueScript : AudioBase, IGetValue,IReceiveDamage
{
    /// <summary>
    /// デバッグモードTrueにすると攻撃を受けない
    /// </summary>
    [Header("【デバッグ用】：?をつけると攻撃を受けない"), SerializeField] public bool _debugMode = false;

    /// <summary> HitPoint </summary>
    [Header("体力"),SerializeField] int _hp = 100;
    int _maxHp;
    [SerializeField] HealthController helth;

    /// <summary>回復力</summary>
    [Header("回復力"), SerializeField] int _resilienceValue = 0;

    /// <summary>EXP</summary>
    [Header("経験値"),SerializeField] public int _exp = 0;
    int _nowExp;
    [SerializeField] EXPController expcontroller; 

    /// <summary> MoveSpeed</summary>
    [Header("移動速度"), SerializeField] float _speed = 5f;

    /// <summary>DefensePower</summary>
    [Header("防御力"), SerializeField] float _defensePower = 5f;

    [HideInInspector] static public bool isGameOver = false;

    [Header("ダメージを受けた時のサウンド"),SerializeField] AudioClip _damageSound;

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
        //hp処理
        helth.UpdateSlider(_hp);
        if (_hp <= 0&& isGameOver == false)
        {
            isGameOver = true;
            Debug.Log("GameOver");
        }
    }
    /// <summary>
    /// EXP加算処理
    /// </summary>
    /// <param name="getexp"></param>
    public void GetEXP(int getexp)
    {
        _exp += getexp;
    }

    /// <summary>
    /// ダメージ処理
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
