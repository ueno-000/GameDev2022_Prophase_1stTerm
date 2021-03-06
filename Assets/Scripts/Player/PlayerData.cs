using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    public List<PlayerDataBase> _playerDataBases = new List<PlayerDataBase>();
}

[System.Serializable]
public class PlayerDataBase
{
    public string m_name;
    [SerializeField, Header("画像 いらんかも")] Sprite _image;

    [SerializeField, Header("体力")] int _life;
    [SerializeField, Header("スキル")] int _skill;
    [SerializeField, Header("速度")] float _speed;
    public Sprite Image => _image;
    public int Life => _life;
    public int Skill => _skill;
    public float Speed => _speed;
}