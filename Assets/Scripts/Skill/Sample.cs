using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    [SerializeField] private GameObject[] _cells;
    [SerializeField] private int _selectedIndex;

    private void Start()
    {
        SelectedColor();
    }

    private void Update()
    {
        _selectedIndex = Mathf.Clamp(_selectedIndex, 0, _cells.Length-1);

        if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.W)) 
        {
            if (_selectedIndex - 1 >= 0)
            {
                _selectedIndex--;
                SelectedColor();
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)|| Input.GetKeyDown(KeyCode.S)) 
        {
            if (_selectedIndex+ 1 < _cells.Length)
            {
                _selectedIndex++;
                SelectedColor();
            }
        }

    }
    /// <summary>
    /// 選択するメソッド
    /// </summary>
    private void SelectedColor()
    {
        for (var i = 0; i < _cells.Length; i++)
        {
            var cell = _cells[i];

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
}
