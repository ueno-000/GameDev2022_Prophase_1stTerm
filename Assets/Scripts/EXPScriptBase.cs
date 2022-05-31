using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EXPScriptBase : MonoBehaviour
{
    [Header("‚Á‚Ä‚¢‚éŒoŒ±’l"), SerializeField] int _receiveEXP = 1;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        col.GetComponent<IGetValue>().GetEXP(_receiveEXP);
    }
}
