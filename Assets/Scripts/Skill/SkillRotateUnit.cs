using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 /// <summary>
 /// ���񂷂�I�u�W�F�N�g�ɓ�����ƓG�ɍU��������
 /// </summary>
public class SkillRotateUnit : SkillBase
{
    /// <summary> �U���� </summary>
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