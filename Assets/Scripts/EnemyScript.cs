using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damageValue = 5;
    GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _speed / 100);
    }

    
    private void OnCollisionStay2D(Collision2D collision)
    {
        var damagetarget = _player.GetComponent<IReceiveDamage>();

        //IDamagable ÇÕ AddDamage ÇÃèàóùÇ™ïKê{
        if (damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

}
