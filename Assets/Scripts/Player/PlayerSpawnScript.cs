using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpawnScript : MonoBehaviour
{
    [SerializeField] PlayerData _playerData = null;

    /// <summary>��������v���C���[�̃f�[�^ID</summary>
    [SerializeField] static public int _charaID = 0;
    /// <summary>��������v���C���[��HP</summary>
    [SerializeField] static public int _hp = 0;
    /// <summary>��������v���C���[��Speed</summary>
    [SerializeField] static public int _speed = 0;

    /// <summary>�v���C���[</summary>
    [SerializeField] GameObject[] _player = null;
    /// <summary>�v���C���[�X�L��</summary>
    [SerializeField] public GameObject[] _skills = null;
    /// <summary>�\���X�L���̃X�v���C�g</summary>
    [Header("�X�L���̃X�v���C�g(��Ɠ����X�L�����ɂ���)"), SerializeField] public Sprite[] _sprites;
    /// <summary>�X�L���\����Image</summary>
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
