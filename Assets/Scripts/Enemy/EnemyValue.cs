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
        //Player�^�O�̃I�u�W�F�N�g���擾
        _player = GameObject.Find("Player");
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var _pPosition = _player.transform.position;
        var _ePosition = this.transform.position;

        // �v���C���[�̕����ɓ����x�N�g��(move_speed�ő��x�𒲐�)
        Vector3 force = (_ePosition - _pPosition)*_speed;
        // ���킶��ǐ�
        _rb.AddForce(force, ForceMode.Force);
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
