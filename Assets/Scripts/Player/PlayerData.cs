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
    [SerializeField, Header("�摜 ����񂩂�")] Sprite _image;

    [SerializeField, Header("�̗�")] int _life;
    [SerializeField, Header("�X�L��")] int _skill;
    [SerializeField, Header("���x")] float _speed;
    public Sprite Image => _image;
    public int Life => _life;
    public int Skill => _skill;
    public float Speed => _speed;
}