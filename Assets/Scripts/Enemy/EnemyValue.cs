using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyValue : MonoBehaviour, IReceiveDamage
{
    [SerializeField] int _damageValue = 2;
    [SerializeField] int _hp = 5;
    [SerializeField] float _speed = 5;
    //Player
    GameObject _player;
    bool isGameOver = false;

    Rigidbody _rb;
    void Start()
    {
        //Playerタグのオブジェクトを取得
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var _pPosition = _player.transform.position;
        var _ePosition = this.transform.position;

        // プレイヤーの方向に動くベクトル(move_speedで速度を調整)
        Vector3 force = (_ePosition - _pPosition)*_speed;
        // じわじわ追跡
        _rb.AddForce(force, ForceMode.Force);
    }

    private void OnCollisionStay(Collision collision)
    {
        var damagetarget = _player.GetComponent<IReceiveDamage>();

        //IDamagable は AddDamage の処理が必須
        if (damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }


    public void ReceiveDamage(int damage)
    {
        if (isGameOver == false)
        {
            _hp -= damage;
            Debug.Log("Enemyがダメージを受けた");
        }
    }
}
