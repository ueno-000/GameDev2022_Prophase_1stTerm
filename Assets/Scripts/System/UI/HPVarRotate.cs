using UnityEngine;

public class HPVarRotate : MonoBehaviour
{
    void LateUpdate()
    {
        //�@�J�����Ɠ��������ɐݒ�
        transform.rotation = Camera.main.transform.rotation;
    }
}
