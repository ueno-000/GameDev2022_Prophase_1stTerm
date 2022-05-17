using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] int _damageValue = 2;
    /// <summary>
    /// NavMesh Agent コンポーネントを格納する変数
    /// </summary>
    [HideInInspector]
    public NavMeshAgent _agent;

    //Player
    GameObject _player;

    void Start()
    {
        //Playerタグのオブジェクトを取得
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        // autoBraking を無効にする事で、目標地点の間を継続的に移動する(エージェントは目標地点に近づいても速度をおとさない)
        _agent.autoBraking = false;
        _agent.speed = 1;
    }

    void Update()
    {
        _agent.destination = _player.transform.position;
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
