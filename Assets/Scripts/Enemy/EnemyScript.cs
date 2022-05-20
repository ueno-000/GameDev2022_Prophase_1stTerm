using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour, IReceiveDamage
{
    [SerializeField] float _speed = 5f;
    [SerializeField] int _damageValue = 5;
    [SerializeField] int _hp = 5;
    [SerializeField] int _retentionEXPvalue = 10;

    NavMeshAgent _agent;
    Transform _player;
    bool isGameOver = false;

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

        //IDamagable �� AddDamage �̏������K�{
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
            Debug.Log("Enemy���_���[�W���󂯂�");
        }
    }
}
