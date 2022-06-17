using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttons;
    [SerializeField] GameObject[] _skills;
    [SerializeField] private int _selectedIndex;
    [SerializeField] PlayerSpawnScript _data;

    int _getSkill = 1;
    private void Start()
    {
        Pause();
        SelectedColor();
        var player = GameObject.Find("Player").GetComponent<PlayerValueScript>();
        for (int i = 0; i < _buttons.Length; i++)
        {
            var index = i;
            var btn = _buttons[i].GetComponentInChildren<UnityEngine.UI.Button>();
            btn.onClick.AddListener(() =>
                OnClick(index)
            );

        }
    }


    private void Update()
    {
        Select();
    }


    /// <summary>
    /// 選択するメソッド
    /// </summary>
    private void Select()
    {
        Pause();
        _selectedIndex = Mathf.Clamp(_selectedIndex, 0, _buttons.Length - 1);

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (_selectedIndex - 1 >= 0)
            {
                _selectedIndex--;
                SelectedColor();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (_selectedIndex + 1 < _buttons.Length)
            {
                _selectedIndex++;
                SelectedColor();
            }
        }
    }

    /// <summary>
    /// 色を変えるメソッド
    /// </summary>
    public void SelectedColor()
    {
        for (var i = 0; i < _buttons.Length; i++)
        {
            var cell = _buttons[i];

            var image = cell.GetComponent<Image>();

            if (i == _selectedIndex)
            {
                image.color = Color.red;
            }

            else
            {
                image.color = Color.white;
            }
        }
    }


    private void OnClick(int index)
    {
        switch (index)
        {
            case 0:
                _skills[PlayerSpawnScript._charaID].GetComponent<SkillBase>()._skillLevel++;
                break;
            case 1:
                if (_getSkill <= 2)
                {
                    int ram = Random.Range(0, _skills.Length);
                    int num = ram;
                    if (num != PlayerSpawnScript._charaID)
                    {
                        _skills[num].SetActive(true);
                        _data._image[_getSkill] = _data._image[_getSkill].GetComponent<Image>();
                        _data._image[_getSkill].sprite = _data._sprites[num];
                        _data._image[_getSkill].color = new Color(255, 255, 255, 255);

                        _getSkill++;
                    }
                    else { return; }
                }
                else
                {
                    _skills[_getSkill-1].GetComponent<SkillBase>()._skillLevel++;
                    _skills[_getSkill].GetComponent<SkillBase>()._skillLevel++;
                }

                break;
            case 2:
                GameObject.Find("Player").GetComponent<PlayerValueScript>().Recovery();
                break;

        }
        Resume();
       this.gameObject.SetActive(false);
  
    }

    /// <summary>
    /// 一時停止のメソッド
    /// </summary>
    void Pause()
    {
        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Pause を呼ぶ
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();
            i?.Pause(999);
            
        }
    }
    /// <summary>
    /// 再開のメソッド
    /// </summary>
    void Resume()
    {
        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Resume を呼ぶ
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();
            i?.Resume();
        }
    }
}
