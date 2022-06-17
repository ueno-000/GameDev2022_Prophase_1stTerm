using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSkill : SkillBase,IPause
{
    /// <summary> 効果時間</summary>
    [SerializeField]  float[] _coolUp = new float[] { 0.5f,1f,1.5f,2f,3f};
    /// <summary> クールダウン</summary>
    [SerializeField] float[] _coolDown = new float[] {10,10,8,8,5};
    /// <summary> 生成位置 </summary>
    [SerializeField] Vector3[] _pos = new Vector3[6];

    [SerializeField] Transform _player;

    [SerializeField] BoxCollider _collider;

    float time;
    GameObject _child;
    bool isPause;

    private void Start()
    {
        time = 0;
        _child = transform.GetChild(0).gameObject;

        _child.SetActive(false);

        isPause = false;
    }
    
    private void Update()
    {
        if(!isPause)
        time += Time.deltaTime;

        ObjectDev();
    }

    private void ObjectDev()
    {
        if (time >= _coolDown[_skillLevel - 1])
        {
            //生成する位置をランダムで決める
            int num = Random.Range(0, 5);

            _child.SetActive(true);
            _collider.enabled = true;

            //自身の位置を変える
            this.gameObject.transform.position = _player.position + _pos[num];

            time = 0;

            StartCoroutine("Stop");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<IPause>().Pause(_coolUp[_skillLevel]);
            
        }
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(_coolUp[_skillLevel-1]);
        _collider.enabled = false;
        _child.SetActive(false);
    }

    public void Pause(float time)
    {
        isPause = true;
    }
    public void Resume()
    {
        isPause = false;
    }
}
