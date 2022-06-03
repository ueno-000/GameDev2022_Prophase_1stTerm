using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    /// <summary>与ダメージ増加</summary>
    [Header("与ダメージ増加"), SerializeField] public int _increaseDamage;
    [SerializeField] public bool isIncreaseDamage;
    /// <summary>被ダメージ減少</summary>
    [Header("被ダメージ減少"), SerializeField] public int _decreaseDamage;
    [SerializeField] public bool isDecreaseDamage;
    /// <summary>毎秒回復</summary>
    [Header("毎秒回復"), SerializeField] public float _everyRecovery;
    [SerializeField] public bool isEveryRecovery;
    /// <summary>クールダウン減少</summary>
    [Header("クールダウン減少"), SerializeField] public float _coolDown;
    [SerializeField] public bool isCoolDown;
    /// <summary>武器効果時間UP</summary>
    [Header("武器効果時間UP"), SerializeField] public float _increasedDuration;
    [SerializeField] public bool isIncreaseDuration;
    /// <summary>移動速度上昇</summary>
    [Header("移動速度上昇"), SerializeField] public float _movingSpeedUP;
    [SerializeField] public bool isMovingSpeedUP;
    /// <summary>経験値獲得量UP</summary>
    [Header("経験値獲得量UP"), SerializeField] public int _increaseEXP;
    [SerializeField] public bool isIncreaseEXP;
    /// <summary>復活</summary>
    [Header("復活"), SerializeField] public int _revivalCount;
    [SerializeField] public bool isRevivalCount;

    private void Update()
    {
        
    }

}
