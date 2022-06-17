using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// 旋回するオブジェクトに当たると敵に攻撃が入る
 /// </summary>
public class SkillRotateUnit : SkillBase,IPause
{
    /// <summary> 攻撃力 </summary>
    [SerializeField] public int[]  _damageValue = new int[5] {2,2,2,2,10};

    [SerializeField] Transform _player;
    Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        this.gameObject.transform.position = _player.position;

        switch (_skillLevel)
        {
            case 2:
                _anim.SetBool("isBool1", true);
                break;
            case 3:
                _anim.SetBool("isBool2", true);
                break;
            case 4:
                _anim.SetBool("isBool4", true);
                break;
        }
    }

    public void Pause(float time)
    {
        _anim.SetFloat("MovingSpeed", 0.0f); // 一時停止
    }
    public void Resume()
    {
        _anim.SetFloat("MovingSpeed", 1.0f); // 再開
    }
}