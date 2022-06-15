using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HC.Debug;

/// <summary>
/// �_���[�W����̃V�[���h
/// </summary>
public class SkillShield : SkillBase
{
    /// <summary>�U���͈�</summary>
    [Header("Player��AttachedSkillObject��StreetLight���A�^�b�`"), SerializeField] SphereCollider _shieldAreaCol;

    [Header("�G���A"),SerializeField] float[] _radius = new float[5] {0.5f,0.5f,0.5f,0.5f,1};
    [Header("�N�[���_�E��"),SerializeField] float[] _coolDown = new float[5] {10f,10f,7f,7f,5f};
    [Header("��������"), SerializeField] float[] _coolUp = new float[5] {5f,10f,10f,10f,15f};

    [SerializeField] PlayerValueScript _playerValueScript;

    bool _isCheet = false;
    [SerializeField] float _time;
    //=====Physics Debugge�̐ݒ�=====
    [Header("���R���C�_�[�̐F"), Header("Physics Debugge�̐ݒ�"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("���b�Z�[�W"), SerializeField]
    private string _message;
    [Header("�t�H���g�T�C�Y"), SerializeField]
    private int _fontSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        _shieldAreaCol = _shieldAreaCol.GetComponent<SphereCollider>();
        _shieldAreaCol.radius = _radius[_skillLevel - 1];
        _shieldAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _isCheet = true;
    }

    // Update is called once per frame
    void Update()
    {
        _playerValueScript.gameObject.GetComponent<PlayerValueScript>()._debugMode = _isCheet;
        _time += Time.deltaTime;
        Shield();
    }


    private void Shield()
    {
        //�������Ԃ��I�������Shield������
        if (_isCheet && _time >= _coolUp[_skillLevel-1])
        {
            Destroy(transform.GetChild(0).gameObject);
            _time = 0;
            _isCheet = false;
        }
        //�N�[���_�E�����I�������Shield��t����
        if (!_isCheet && _time >= _coolDown[_skillLevel-1])
        {
            _shieldAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
            _time = 0;
            _isCheet = true;
        }

        //���x���A�b�v����
        if (_isLevelUp)
        {
            Destroy(transform.GetChild(0).gameObject);
            _shieldAreaCol.radius = _radius[_skillLevel - 1];
            _shieldAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
            _isLevelUp = false;
        }
    }
}
