using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 旋回するオブジェクトに当たると敵に攻撃が入る
 /// </summary>
public class SkillRotateUnit : SkillBase
{
    /// <summary> 攻撃力 </summary>
    [SerializeField] public int  _damageValue = 1;

    [SerializeField] Transform _player;
    Animator _anim;

    private void Start()
    {
    }

    private void Update()
    {
        this.gameObject.transform.position = _player.position;
    }

}