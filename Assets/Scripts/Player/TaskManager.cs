using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    /// <summary>�^�_���[�W����</summary>
    [Header("�^�_���[�W����"), SerializeField] public int _increaseDamage;
    [SerializeField] public bool isIncreaseDamage;
    /// <summary>��_���[�W����</summary>
    [Header("��_���[�W����"), SerializeField] public int _decreaseDamage;
    [SerializeField] public bool isDecreaseDamage;
    /// <summary>���b��</summary>
    [Header("���b��"), SerializeField] public float _everyRecovery;
    [SerializeField] public bool isEveryRecovery;
    /// <summary>�N�[���_�E������</summary>
    [Header("�N�[���_�E������"), SerializeField] public float _coolDown;
    [SerializeField] public bool isCoolDown;
    /// <summary>������ʎ���UP</summary>
    [Header("������ʎ���UP"), SerializeField] public float _increasedDuration;
    [SerializeField] public bool isIncreaseDuration;
    /// <summary>�ړ����x�㏸</summary>
    [Header("�ړ����x�㏸"), SerializeField] public float _movingSpeedUP;
    [SerializeField] public bool isMovingSpeedUP;
    /// <summary>�o���l�l����UP</summary>
    [Header("�o���l�l����UP"), SerializeField] public int _increaseEXP;
    [SerializeField] public bool isIncreaseEXP;
    /// <summary>����</summary>
    [Header("����"), SerializeField] public int _revivalCount;
    [SerializeField] public bool isRevivalCount;

    private void Update()
    {
        
    }

}
