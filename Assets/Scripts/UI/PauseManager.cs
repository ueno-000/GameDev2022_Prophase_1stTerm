using UnityEngine;

/// <summary>
/// �ꎞ��~�E�ĊJ�𐧌䂷��B
/// </summary>
public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject _config;

    /// <summary>true �̎��͈ꎞ��~�Ƃ���</summary>
    bool _pauseFlg = false;

    void Update()
    {
        // ESC �L�[�������ꂽ��ꎞ��~�E�ĊJ��؂�ւ���
        if (Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    /// <summary>
    /// �ꎞ��~�E�ĊJ��؂�ւ���
    /// </summary>
    void PauseResume()
    {
        _pauseFlg = !_pauseFlg;

        // �S�Ă� GameObject ������Ă��āAIPause ���p�������R���|�[�l���g���ǉ�����Ă����� Pause �܂��� Resume ���Ă�
        var objects = FindObjectsOfType<GameObject>();

        foreach (var o in objects)
        {
            IPause i = o.GetComponent<IPause>();

            if (_pauseFlg)
            {
                i?.Pause();     // �����Łu���Ԑ��v���g���Ă���
                _config.SetActive(true);
            }
            else
            {
                i?.Resume();    // �����Łu���Ԑ��v���g���Ă���
                _config.SetActive(false);
            }
        }
    }
}
