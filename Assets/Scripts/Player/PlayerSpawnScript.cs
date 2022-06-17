using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;

    /// <summary>生成するプレイヤーのデータID</summary>
    [SerializeField] static public int _charaID = 0;
    /// <summary>生成するプレイヤーのHP</summary>
    [SerializeField] static public int _hp = 0;
    /// <summary>生成するプレイヤーのSpeed</summary>
    [SerializeField] static public int _speed = 0;

    /// <summary>プレイヤー</summary>
    [SerializeField] GameObject[] _player = null;
    /// <summary>プレイヤースキル</summary>
    [SerializeField] public GameObject[] _skills = null;
    /// <summary>表示スキルのスプライト</summary>
    [Header("スキルのスプライト(上と同じスキル順にする)"), SerializeField] public Sprite[] _sprites;
    /// <summary>スキル表示のImage</summary>
    [SerializeField] public Image[] _image;

    public int PlayerId { get => _charaID; set => _charaID = value; }
    public int PlayerHelth { get => _hp; set => _hp = value; }
    public int PlayerSpeed { get => _speed; set => _speed = value; }

    void Start()
    {
        if (_player[_charaID])
        {
            _player[_charaID].SetActive(true);
            _skills[_charaID].SetActive(true);
            _image[0] = _image[0].GetComponent<Image>();
            _image[0].sprite = _sprites[_charaID];
            _image[0].color = new Color(255, 255, 255, 255);
        }
        else
        {
            Debug.LogWarning("Player is Null");
        }

    }

    public enum PlayerID
    {
        BlueCar,
        SharkCar
    }
}
