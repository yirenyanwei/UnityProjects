using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBehaviourScript : MonoBehaviour
{
    public string myName;
    public GameObject myPrefab;
    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        //实例化prefab
        Instantiate(myPrefab, new Vector3(2, 2, 2), Quaternion.identity);
        
        GameObject obj = gameObject;
        Transform trans = GetComponent<Transform>();
        Debug.Log(trans.position);
        gameObject.SetActive(false);

        Vector2 vec = Vector2.zero;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("OnDestory");
    }
}
