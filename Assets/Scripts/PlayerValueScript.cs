using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValueScript : MonoBehaviour,IGetValue ,IReceiveDamage
{
    /// <summary>
    /// デバッグモードTrueにすると攻撃を受けない
    /// </summary>
    [Header("【デバッグ用】：?をつけると攻撃を受けない"), SerializeField] bool _debugMode = false;

    [Header("HitPoint")]
    /// <summary>
    /// HitPoint
    /// </summary>
    [SerializeField] int _hp = 100;
    int _maxHp;
    [Header("EXP")]
    /// <summary>
    /// EXP
    /// </summary>
    [SerializeField] int _exp = 0;

    [SerializeField] GameObject HPController;
    [SerializeField] HealthController helth;

    public bool isGameOver = false;

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
        //hp処理
        helth.UpdateSlider(_hp);
        if (_hp <= 0&& isGameOver == false)
        {
            isGameOver = true;
            Debug.Log("GameOver");
            GetComponent<Renderer>().material.color = Color.black;
        }
    }

    public void GetEXP(int getexp)
    {
        _exp += getexp;
    }
    public void ReceiveDamage(int damage)
    {
        if (isGameOver == false && _debugMode == false)
        {
            _hp -= damage;
            Debug.Log("add: " + damage + "hp: " + _hp);
        }
    }
}
