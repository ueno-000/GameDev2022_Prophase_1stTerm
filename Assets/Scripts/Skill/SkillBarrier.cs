using UnityEngine;
using UnityEngine.UI;
using HC.Debug;

/// <summary>
/// �������ꂽ�o���A�ɐG���ƓG�ɍU��������
/// </summary>
public class SkillBarrier : SkillBase
{
    /// <summary>�U���͈�</summary>
    [Header("Player��AttachedSkillObject��Gasoline���A�^�b�`"), SerializeField] SphereCollider _hitAreaCol;

    [SerializeField] float[] _radius = new float[5] {1,1,3,3,5};

    /// <summary> Damage </summary>
    [Header("�_���[�W"), SerializeField] int[] _damageValue =new int[5] {1,2,2,3,5};

    //=====Physics Debugge�̐ݒ�=====
    [Header("���R���C�_�[�̐F"), Header("Physics Debugge�̐ݒ�"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("���b�Z�[�W"), SerializeField]
    private string _message;
    [Header("�t�H���g�T�C�Y"), SerializeField]
    private int _fontSize = 1;

    private void Start()
    {
        _hitAreaCol = _hitAreaCol.GetComponent<SphereCollider>();
        _hitAreaCol.radius = _radius[_skillLevel - 1];
        _hitAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
    }
    private void Update()
    {
        Attack();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue[_skillLevel-1]);
        }
    }

    private void Attack()
    {
        if (_isLevelUp)
        {
            Destroy(transform.GetChild(0).gameObject);
            _hitAreaCol.radius = _radius[_skillLevel - 1];
            _hitAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
            _isLevelUp = false;
        }
    }

}
