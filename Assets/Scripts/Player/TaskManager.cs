using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    /// <summary>^_[WÁ</summary>
    [Header("^_[WÁ"), SerializeField] public int _increaseDamage;
    [SerializeField] public bool isIncreaseDamage;
    /// <summary>í_[W¸­</summary>
    [Header("í_[W¸­"), SerializeField] public int _decreaseDamage;
    [SerializeField] public bool isDecreaseDamage;
    /// <summary>bñ</summary>
    [Header("bñ"), SerializeField] public float _everyRecovery;
    [SerializeField] public bool isEveryRecovery;
    /// <summary>N[_E¸­</summary>
    [Header("N[_E¸­"), SerializeField] public float _coolDown;
    [SerializeField] public bool isCoolDown;
    /// <summary>íøÊÔUP</summary>
    [Header("íøÊÔUP"), SerializeField] public float _increasedDuration;
    [SerializeField] public bool isIncreaseDuration;
    /// <summary>Ú®¬xã¸</summary>
    [Header("Ú®¬xã¸"), SerializeField] public float _movingSpeedUP;
    [SerializeField] public bool isMovingSpeedUP;
    /// <summary>o±ll¾ÊUP</summary>
    [Header("o±ll¾ÊUP"), SerializeField] public int _increaseEXP;
    [SerializeField] public bool isIncreaseEXP;
    /// <summary></summary>
    [Header(""), SerializeField] public int _revivalCount;
    [SerializeField] public bool isRevivalCount;

    private void Update()
    {
        
    }

}
