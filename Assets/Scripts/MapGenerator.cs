using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    /// <summary> Player </summary>
    [SerializeField] Transform Target;
    /// <summary> �X�e�[�W�̃v���n�u </summary>
    [Header("�X�e�[�W�̃v���n�u"), SerializeField] GameObject[] stagenum;
    /// <summary>//�X�^�[�g�O�̃X�e�[�W�̐�</summary>
    [Header("�X�^�[�g�O�̃X�e�[�W�̐�"), SerializeField] int FirstStageIndex;
    /// <summary> ��������X�e�[�W�̐� </summary>
    [Header("��������X�e�[�W�̗�"), SerializeField] int aheadStage;
    /// <summary> ���������X�e�[�W�̃��X�g</summary>
    [Header("���������X�e�[�W�̃��X�g"), SerializeField] List<GameObject> StageList = new List<GameObject>();
    /// <summary> ��A�N�e�B�u�ɂ����X�e�[�W�̃��X�g</summary>
    [Header("��A�N�e�B�u�ɂ����X�e�[�W�̃��X�g"), SerializeField] List<GameObject> FalseList = new List<GameObject>();

    [Header("�X�e�[�W�O���b�g���X�g"), SerializeField]
    private List<stageList> GritList = new List<stageList>();

    [System.Serializable]
    class stageList
    {
        public List<int> StageGrit = new List<int>();
    }

    [SerializeField] int _mapXnum = 2;
    [SerializeField] int _mapZnum = 2;


    [SerializeField] int targetPosIndexX;
    [SerializeField] int targetPosIndexZ;

    int StageSize = 84;

    int StageIndex;

    /// <summary>
    /// �X�e�[�W�������̉�]�Ɏg��
    /// </summary>
    float[] _mapRotates = new float[4] { 0, 90, 180, -90 };

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;/*new int[FirstStageIndex - 1, FirstStageIndex - 1];*/
        StageManager(aheadStage);
    }


    void Update()
    {
        targetPosIndexX = (int)(Target.position.x / StageSize);
        targetPosIndexZ = (int)(Target.position.z / StageSize);

        //�v���C���[���X�e�[�W�ړ�������̏���
        //
        if (targetPosIndexZ + aheadStage > StageIndex)
        {
            StageManager(targetPosIndexZ + aheadStage);
        }
    }

    /// <param name="maps">������X�e�[�W�̐�</param>
    void StageManager(int maps)
    {
        if (maps <= StageIndex)
        {
            return;
        }

        for (int i = StageIndex + 1; i <= maps; i++)//�w�肵���X�e�[�W�܂ō쐬����
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 2)//�Â��X�e�[�W���폜����
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    /// <summary>
    /// �X�e�[�W�����̃��\�b�h
    /// </summary>
    /// <param name="index">�X�e�[�W�̃C���f�b�N�X</param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        //��������X�e�[�W�������_���ɑI������
        int nextStage = Random.Range(0, stagenum.Length);
        //��������p�x�������_���ɑI������
        int rotateStage = Random.Range(0, _mapRotates.Length);

        GameObject stageObject =
            Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.Euler(0, _mapRotates[rotateStage], 0));

        return stageObject;
    }
    /// <summary>
    /// �X�e�[�W���������\�b�h
    /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        oldStage.SetActive(false);
        FalseList.Add(oldStage);
    }

}
