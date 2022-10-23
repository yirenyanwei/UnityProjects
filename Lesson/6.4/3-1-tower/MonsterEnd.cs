using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnd : MonoBehaviour
{
    public int GameHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            Destroy(other.gameObject);
            if (GameHealth--<=0)
            {
                Debug.Log("Game Over");
            }
        }
    }
}
