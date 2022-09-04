using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [Header("金币生成范围")]
    public float Range;
    public GameObject coinPrefab;
    [Header("金币生成的间隔")]
    public float Interval = 1f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=Interval)
        {
            timer = 0;
            //生成coin
            GameObject coin = Instantiate(coinPrefab, 
                new Vector3(Random.Range(-Range,Range), 8, 0), 
                Quaternion.identity);
            Destroy(coin, 3);
        }
        
    }
}
