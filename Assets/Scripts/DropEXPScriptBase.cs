using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEXPScriptBase : MonoBehaviour
{
    [Header("éùÇ¡ÇƒÇ¢ÇÈåoå±íl"), SerializeField] int _receiveEXP = 1;
    [SerializeField] bool isManyEXP;
    int _nowMaxEXP;

    private void OnTriggerEnter(Collider col)
    {
        if (isManyEXP && col.gameObject.tag == "Player")
        {
            _nowMaxEXP = GameObject.Find("EXPSlider").GetComponent<EXPController>()._maxNowLevelExp;
            col.GetComponent<IGetValue>().GetEXP(_nowMaxEXP/2);
           this.gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "Player")
        {
            col.GetComponent<IGetValue>().GetEXP(_receiveEXP);
            this.gameObject.SetActive(false);
        }
    }
}
