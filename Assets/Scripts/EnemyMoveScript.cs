using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveScript : MonoBehaviour
{
    [SerializeField] int _damageValue = 2;
    /// <summary>
    /// NavMesh Agent �R���|�[�l���g���i�[����ϐ�
    /// </summary>
    [HideInInspector]
    public NavMeshAgent _agent;

    //Player
    GameObject _player;

    void Start()
    {
        //Player�^�O�̃I�u�W�F�N�g���擾
        _player = GameObject.Find("Player");
        _agent = GetComponent<NavMeshAgent>();
        // autoBraking �𖳌��ɂ��鎖�ŁA�ڕW�n�_�̊Ԃ��p���I�Ɉړ�����(�G�[�W�F���g�͖ڕW�n�_�ɋ߂Â��Ă����x�����Ƃ��Ȃ�)
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

        //IDamagable �� AddDamage �̏������K�{
        if (damagetarget != null)
        {
            _player.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }
}
