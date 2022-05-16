using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damageValue = 5;
    [SerializeField] float _hp = 5f;
    [SerializeField] int _retentionEXPvalue = 10;

    GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed / 100);

        if (_hp <= 0)
        {
            var receiveEXP = _player.GetComponent<IGetValue>();
            //IDamagable は AddDamage の処理が必須
            if (receiveEXP != null)
            {
                _player.GetComponent<IGetValue>().GetEXP(_retentionEXPvalue);
            }
            Destroy(gameObject);
        }
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

}
