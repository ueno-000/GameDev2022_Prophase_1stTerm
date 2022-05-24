using UnityEngine;

/// <summary>
/// 一時停止・再開を制御する。
/// </summary>
public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject _config;

    /// <summary>true の時は一時停止とする</summary>
    bool _pauseFlg = false;

    void Update()
    {
        // ESC キーが押されたら一時停止・再開を切り替える
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// 一時停止・再開を切り替える
    /// </summary>
    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;

        // 全ての GameObject を取ってきて、IPause を継承したコンポーネントが追加されていたら Pause または Resume を呼ぶ
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_pauseFlg)
            {
                i?.Pause();     // ここで「多態性」が使われている
                _config.SetActive(true);
            }
            else
            {
                i?.Resume();    // ここで「多態性」が使われている
                _config.SetActive(false);
            }
        }
    }
}
