using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValueScript : MonoBehaviour,IReceiveDamage
{
    [SerializeField] int _hp = 100;

    public bool isGameOver = false;

    void Start()
    {
       _hp = Mathf.Clamp(_hp, 0, 100);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveDamage(int damage)
    {
        if (isGameOver == false)
        {
            _hp -= damage;
            Debug.Log("add: " + damage + "hp: " + _hp);

            if (_hp <= 0)
            {
                isGameOver = true;
                Debug.Log("GameOver");
            }
        }
    }
}
