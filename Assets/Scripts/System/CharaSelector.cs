using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Cinemachine;

/// <summary>
/// キャラクター選択
/// </summary>
public class CharaSelector : MonoBehaviour
{
    [SerializeField] EventSystem _eventSystem;
    [SerializeField] Text[] _texts;
    [SerializeField] GameObject _firstObj;

    // バーチャルカメラ一覧
    [SerializeField] private CinemachineVirtualCamera[] _virtualCameraList;
    // 非選択時のバーチャルカメラの優先度
    [SerializeField] private int _unselectedPriority = 0;
    // 選択時のバーチャルカメラの優先度
    [SerializeField] private int _selectedPriority = 10;
    // 選択中のバーチャルカメラのインデックス
    private int _currentCamera = 0;

    // バーチャルカメラの優先度初期化
    private void Awake()
    {
        // バーチャルカメラが設定されていなければ、何もしない
        if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
            return;

        // バーチャルカメラの優先度を初期化
        for (var i = 0; i < _virtualCameraList.Length; ++i)
        {
            _virtualCameraList[i].Priority =
                (i == _currentCamera ? _selectedPriority : _unselectedPriority);
        }
    }
    private void Start()
    {
        TextMethod(_firstObj);
    }
    // フレーム更新
    private void Update()
    {
        // バーチャルカメラが設定されていなければ、何もしない
        if (_virtualCameraList == null || _virtualCameraList.Length <= 0)
            return;

    }

    public void ChangeCamera(int num)
    {
        // 以前のバーチャルカメラを非選択
        var vCamPrev = _virtualCameraList[_currentCamera];
        vCamPrev.Priority = _unselectedPriority;

        // 追従対象を順番に切り替え

         _currentCamera = num;

        // 次のバーチャルカメラを選択
        var vCamCurrent = _virtualCameraList[_currentCamera];
        vCamCurrent.Priority = _selectedPriority;
    }
    public void TextMethod(GameObject obj)
    {
        _texts[0].text = obj.GetComponent<State>().NAME.ToString();
        _texts[1].text = "SPD:+" + obj.GetComponent<State>().SPD.ToString();
        _texts[2].text = "HP:+" + obj.GetComponent<State>().HP.ToString();
        _texts[3].text = obj.GetComponent<State>().FlavorText.ToString();
    }
}