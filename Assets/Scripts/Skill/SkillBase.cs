using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e�U���X�L���̃x�[�X�ƂȂ�X�N���v�g
/// </summary>
public class SkillBase : MonoBehaviour
{
    [SerializeField] public int _skillLevel = 1;

    [SerializeField] public bool _isLevelUp = false;

    private void Start()
    {
        _skillLevel = 1;
    }

}
