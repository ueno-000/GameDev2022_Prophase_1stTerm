using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetting : AudioBase
{
    /// <summary>buttonにマウスをかざした時に表示されるスプライト</summary>
    [SerializeField] GameObject _ButtonBackImage;


    [Header("クリック時のサウンド"), SerializeField] private AudioClip _clickSound;

    [Header("カーソルがかぶった時のサウンド"), SerializeField] private AudioClip _cursorSound;

    // マウスカーソルが対象オブジェクトに重なっている間コールされ続ける
    public void OnMouseEnter()
    {
        _ButtonBackImage.SetActive(true);
        Play(_cursorSound,0.8f);
    }
    // マウスカーソルが対象オブジェクトから退出した時にコールされる
    public void OnMouseExit()
    {
        _ButtonBackImage.SetActive(false);
    }

    public void OnClick()
    {
        Play(_clickSound,0.8f);
    }


}
