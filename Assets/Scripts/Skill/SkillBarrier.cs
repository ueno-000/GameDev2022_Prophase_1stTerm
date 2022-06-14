using UnityEngine;
using UnityEngine.UI;
using HC.Debug;

/// <summary>
/// 可視化されたバリアに触れると敵に攻撃が入る
/// </summary>
public class SkillBarrier : SkillBase
{
    /// <summary>攻撃範囲</summary>
    [Header("Player→AttachedSkillObject→Gasolineをアタッチ"), SerializeField] SphereCollider _hitAreaCol;

    [SerializeField] float[] _radius = new float[5] {1,1,3,3,5};

    /// <summary> Damage </summary>
    [Header("ダメージ"), SerializeField] int[] _damageValue =new int[5] {1,2,2,3,5};

    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"), SerializeField]
    private string _message;
    [Header("フォントサイズ"), SerializeField]
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
