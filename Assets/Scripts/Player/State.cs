using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField] int _sPD;
    public int SPD
    {
        get
        {
            return _sPD;
        }
    }

    [SerializeField] int _hP;
    public int HP
    {
        get
        {
            return _hP;
        }
    }
    [SerializeField] string _name;
    public string NAME
    {
        get
        {
            return _name;
        }
    }

    [SerializeField, TextArea(1, 3)] string _flavorText;
    public string FlavorText
    {
        get
        {
            return _flavorText;
        }
    }
}
