using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class SkillRotateUnit : SkillBase
{
    /// <summary> �U���� </summary>
    [SerializeField]int  _damageValue = 1;
    //��
    [SerializeField] int _num = 1;
    //�@���݂̊p�x
    private float angle;
    //�@��]����X�s�[�h
    [Header("��]����X�s�[�h"),SerializeField] private float _rotateSpeed = 180f;
    //�@�^�[�Q�b�g����̋���
    [Header("�^�[�Q�b�g����̋���"),SerializeField] private Vector3 _distanceFromTarget = new Vector3(0f, 1f, 2f);

     [SerializeField] private GameObject _player;

    void Awake()
    {
      // _player = transform.root.gameObject;
    }

    void Update()
    {
        //�@���j�b�g�̈ʒu = �^�[�Q�b�g�̈ʒu �{ �^�[�Q�b�g���猩�����j�b�g�̊p�x �~�@�^�[�Q�b�g����̋���
        transform.position = _player.transform.position + Quaternion.Euler(0f, angle, 0f) * _distanceFromTarget;
        //�@���j�b�g���g�̊p�x = �^�[�Q�b�g���猩�����j�b�g�̕����̊p�x���v�Z����������j�b�g�̊p�x�ɐݒ肷��
        transform.rotation = Quaternion.LookRotation
            (transform.position - new Vector3(_player.transform.position.x, transform.position.y-90, _player.transform.position.z), Vector3.up);
        //�@���j�b�g�̊p�x��ύX
        angle += _rotateSpeed * Time.deltaTime;
        //�@�p�x��0�`360�x�̊ԂŌJ��Ԃ�
        angle = Mathf.Repeat(angle, 360f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }
}