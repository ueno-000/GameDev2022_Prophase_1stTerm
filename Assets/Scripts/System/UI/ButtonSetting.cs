using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : AudioBase
{
    /// <summary>button�Ƀ}�E�X�������������ɕ\�������X�v���C�g</summary>
    [SerializeField] GameObject _ButtonBackImage;


    [Header("�N���b�N���̃T�E���h"), SerializeField] private AudioClip _clickSound;

    [Header("�J�[�\�������Ԃ������̃T�E���h"), SerializeField] private AudioClip _cursorSound;

    // �}�E�X�J�[�\�����ΏۃI�u�W�F�N�g�ɏd�Ȃ��Ă���ԃR�[�����ꑱ����
    public void OnMouseEnter()
    {
        _ButtonBackImage.SetActive(true);
        Play(_cursorSound,0.8f);
    }
    // �}�E�X�J�[�\�����ΏۃI�u�W�F�N�g����ޏo�������ɃR�[�������
    public void OnMouseExit()
    {
        _ButtonBackImage.SetActive(false);
    }

    public void OnClick()
    {
        Play(_clickSound,0.8f);
    }


}
