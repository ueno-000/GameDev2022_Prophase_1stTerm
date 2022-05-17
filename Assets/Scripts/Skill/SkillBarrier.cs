using UnityEngine;
using UnityEngine.UI;
using HC.Debug;

/// <summary>
/// �������ꂽ�o���A�ɐG���ƓG�ɍU��������
/// </summary>
public class SkillBarrier : MonoBehaviour
{
    /// <summary>
    /// �U���͈�
    /// </summary>
    [Header("Player��Skill��[Skill1]���A�^�b�`"), SerializeField] GameObject _hitArea;
    [Header("Player��Skill��[Skill1]���A�^�b�`"), SerializeField] SphereCollider _hitAreaCol;


    //��������ʒu
    [Header("�����ʒu"), SerializeField] Transform _position;

    [SerializeField] GameObject _player;

    /// <summary>
    /// Damage
    /// </summary>
    [Header("�_���[�W"), SerializeField] public int _damage = 10;
    /// <summary>
    /// �C���^�[�o��
    /// </summary>
    [Header("�X�L�����g���Ă���̃C���^�[�o��"), SerializeField] float _skillInterval = 10f;



    //=====Physics Debugge�̐ݒ�=====
    [Header("���R���C�_�[�̐F"), Header("Physics Debugge�̐ݒ�"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("���b�Z�[�W"), SerializeField]
    private string _message;
    [Header("�t�H���g�T�C�Y"), SerializeField]
    private int _fontSize = 1;

    private void Start()
    {
        _hitArea.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _hitAreaCol = _hitArea.GetComponent<SphereCollider>();
    }

}
