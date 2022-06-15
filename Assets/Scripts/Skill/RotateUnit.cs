using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateUnit : MonoBehaviour
{
    /// <summary> çUåÇóÕ </summary>
   int _damageValue = 1;

    int _nowLevel = 0;

    private void Start()
    {
        _damageValue = transform.parent.gameObject.GetComponent<SkillRotateUnit>()._damageValue[0];
        _nowLevel = transform.parent.gameObject.GetComponent<SkillRotateUnit>()._skillLevel;
    }

    private void Update()
    {
        _damageValue = transform.parent.gameObject.GetComponent<SkillRotateUnit>()._damageValue[_nowLevel];
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<IReceiveDamage>().ReceiveDamage(_damageValue);
        }
    }
}
