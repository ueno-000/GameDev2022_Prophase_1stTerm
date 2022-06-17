using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] GameObject[] _skills;

    [Header("スキルのスプライト(上と同じスキル順にする)"), SerializeField] Sprite[] _sprites;

     [SerializeField] Image[] _image = new Image[3];
    private void Update()
    {
        
    }

}
