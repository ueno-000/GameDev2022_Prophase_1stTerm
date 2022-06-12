using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSkill : SkillBase
{
    float[] _effectTime = new float[] { 0.2f,0.5f,1,1.5f,2};


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<IPause>().Pause(_effectTime[_skillLevel]);
        }
    }
}
