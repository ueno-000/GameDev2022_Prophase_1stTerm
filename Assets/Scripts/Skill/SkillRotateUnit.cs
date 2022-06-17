using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// ���񂷂�I�u�W�F�N�g�ɓ�����ƓG�ɍU��������
 /// </summary>
public class SkillRotateUnit : SkillBase,IPause
{
    /// <summary> �U���� </summary>
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
        _anim.SetFloat("MovingSpeed", 0.0f); // �ꎞ��~
    }
    public void Resume()
    {
        _anim.SetFloat("MovingSpeed", 1.0f); // �ĊJ
    }
}