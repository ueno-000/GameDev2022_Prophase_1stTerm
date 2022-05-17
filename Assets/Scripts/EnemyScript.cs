using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damageValue = 5;
    [SerializeField] float _hp = 5f;
    [SerializeField] int _retentionEXPvalue = 10;

    NavMeshAgent _agent;
    Transform _player;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        _agent.destination = _player.position;
    }

    
    private void OnCollisionStay(Collision collision)
    {
        var damagetarget = _player.GetComponent<IReceiveDamage>();

        //IDamagable ÇÕ AddDamage ÇÃèàóùÇ™ïKê{
        if (damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }

}
