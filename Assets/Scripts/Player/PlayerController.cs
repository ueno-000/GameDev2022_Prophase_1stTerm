using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour,IPause
{
    [SerializeField] float _movePower = 3;
    [SerializeField] Transform _muzzle;
    Rigidbody _rb = default;
    /// <summary>���͂��ꂽ������ XZ ���ʂł̃x�N�g��</summary>
    Vector3 _dir;

    // �G�f�B�^����uBulletGenerator�v�X�N���v�g��ݒ�
    public BulletGenerator _bulletGenerator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
        // �J�����̃��[�J�����W�n����� dir ��ϊ�����
        _dir = Camera.main.transform.TransformDirection(_dir);
        // �J�����͎΂߉��Ɍ����Ă���̂ŁAY ���̒l�� 0 �ɂ��āuXZ ���ʏ�̃x�N�g���v�ɂ���
        _dir.y = 0;
        // �L�����N�^�[���u���݂́iXZ ���ʏ�́j�i�s�����v�Ɍ�����
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }

        // �X�y�[�X�L�[�����������A�uPlayer�v�̈ʒu����e�𔭎˂���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _bulletGenerator.FireBullet(_muzzle.position);
        }
    }

    void FixedUpdate()
    {
        // �u�͂�������v�����͗͊w�I�����Ȃ̂� FixedUpdate �ōs������
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }

    public void Pause()
    {
        _rb.Sleep();
        _rb.isKinematic = true;
    }
    public void Resume()
    {
        // Rigidbody �̊������ĊJ���A�ۑ����Ă��������x�E��]��߂�
        _rb.isKinematic = false;
        _rb.WakeUp();
    }

}
