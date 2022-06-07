using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
 
    [SerializeField] GameObject[] _prefabObject;

    private void Start()
    {
        Instantiate(_prefabObject[0],this.transform.position, Quaternion.identity);
    }
}
