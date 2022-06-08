using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    int StageSize = 80;
    int StageIndex;

    /// <summary> Player </summary>
    [SerializeField] Transform Target;
    /// <summary> ステージのプレハブ </summary>
    [Header("ステージのプレハブ"),SerializeField] GameObject[] stagenum;
    /// <summary>//スタート時に生成するステージのインデックス</summary>
    [Header("スタート時に生成するステージのインデックス"), SerializeField] int FirstStageIndex;
    /// <summary> 事前に生成しておくステージのインデックス </summary>
    [Header("事前に生成しておくステージのインデックス"), SerializeField] int aheadStage; //事前に生成しておくステージ
    /// <summary> 生成したステージのリスト</summary>
    [Header("生成したステージのリスト"), SerializeField] List<GameObject> StageList = new List<GameObject>();//生成したステージのリスト

    // Start is called before the first frame update
    void Start()
    {
        StageIndex = FirstStageIndex - 1;
        StageManager(aheadStage);
    }

    // Update is called once per frame
    void Update()
    {
        int targetPosIndex = (int)(Target.position.z / StageSize);

        if (targetPosIndex + aheadStage > StageIndex)
        {
            StageManager(targetPosIndex + aheadStage);
        }
    }
    void StageManager(int maps)
    {
        if (maps <= StageIndex)
        {
            return;
        }

        for (int i = StageIndex + 1; i <= maps; i++)//指定したステージまで作成する
        {
            GameObject stage = MakeStage(i);
            StageList.Add(stage);
        }

        while (StageList.Count > aheadStage + 1)//古いステージを削除する
        {
            DestroyStage();
        }

        StageIndex = maps;
    }

    /// <summary>
    /// ステージ生成のメソッド
    /// </summary>
    /// <param name="index">ステージのインデックス</param>
    /// <returns></returns>
    GameObject MakeStage(int index)
    {
        int nextStage = Random.Range(0, stagenum.Length);

        GameObject stageObject = (GameObject)Instantiate(stagenum[nextStage], new Vector3(0, 0, index * StageSize), Quaternion.identity);

        return stageObject;
    }
        /// <summary>
        /// ステージを消すメソッド
        /// </summary>
    void DestroyStage()
    {
        GameObject oldStage = StageList[0];
        StageList.RemoveAt(0);
        oldStage.SetActive(false);
    }

}
