using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HC.Debug;

/// <summary>
/// ダメージ回避のシールド
/// </summary>
public class SkillShield : SkillBase
{
    /// <summary>攻撃範囲</summary>
    [Header("Player→AttachedSkillObject→StreetLightをアタッチ"), SerializeField] SphereCollider _shieldAreaCol;

    [Header("エリア"),SerializeField] float[] _radius = new float[5] {0.5f,0.5f,0.5f,0.5f,1};
    [Header("クールダウン"),SerializeField] float[] _coolDown = new float[5] {10f,10f,7f,7f,5f};
    [Header("持続時間"), SerializeField] float[] _coolUp = new float[5] {5f,10f,10f,10f,15f};

    [SerializeField] PlayerValueScript _playerValueScript;

    bool _isCheet = false;
    [SerializeField] float _time;
    //=====Physics Debuggeの設定=====
    [Header("可視コライダーの色"), Header("Physics Debuggeの設定"), SerializeField]
    private ColliderVisualizer.VisualizerColorType _visualizerColor;
    [Header("メッセージ"), SerializeField]
    private string _message;
    [Header("フォントサイズ"), SerializeField]
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
        //持続時間が終わったらShieldを消す
        if (_isCheet && _time >= _coolUp[_skillLevel-1])
        {
            Destroy(transform.GetChild(0).gameObject);
            _time = 0;
            _isCheet = false;
        }
        //クールダウンが終わったらShieldを付ける
        if (!_isCheet && _time >= _coolDown[_skillLevel-1])
        {
            _shieldAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
            _time = 0;
            _isCheet = true;
        }

        //レベルアップ処理
        if (_isLevelUp)
        {
            Destroy(transform.GetChild(0).gameObject);
            _shieldAreaCol.radius = _radius[_skillLevel - 1];
            _shieldAreaCol.GetComponent<ColliderVisualizer>().Initialize(_visualizerColor, _message, _fontSize);
            _isLevelUp = false;
        }
    }
}
