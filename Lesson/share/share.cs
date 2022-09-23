using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class share : MonoBehaviour
{
    public int Id = 1;
    private void Awake()
    {
        gameObject.GetComponent<BoxCollider>();
        GameObject.FindWithTag("Player");
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        print("hehe");
        Debug.Log("hehe2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void OnDestroy()
    {
        
    }
}
