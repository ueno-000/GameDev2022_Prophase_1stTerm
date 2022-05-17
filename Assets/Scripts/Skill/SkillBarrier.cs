using UnityEngine;
using UnityEngine.UI;
using HC.Debug;

/// <summary>
/// 可視化されたバリアに触れると敵に攻撃が入る
/// </summary>
public class SkillBarrier : MonoBehaviour
{
    /// <summary>
    /// 攻撃範囲
    /// </summary>
    [Header("Player→Skill→[Skill1]をアタッチ"), SerializeField] GameObject _hitArea;
    [Header("Player→Skill→[Skill1]をアタッチ"), SerializeField] SphereCollider _hitAreaCol;


    //生成する位置
    [Header("生成位置"), SerializeField] Transform _position;

    [SerializeField] GameObject _player;

    /// <summary>
    /// Damage
    /// </summary>
    [Header("ダメージ"), SerializeField] public int _damage = 10;
    /// <summary>
    /// インターバル
    /// </summary>
    [Header("スキルを使ってからのインターバル"), SerializeField] float _skillInterval = 10f;



    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"), SerializeField]
    private string _message;
    [Header("フォントサイズ"), SerializeField]
    private int _fontSize = 1;

    private void Start()
    {
        _hitArea.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
        _hitAreaCol = _hitArea.GetComponent<SphereCollider>();
    }

}
