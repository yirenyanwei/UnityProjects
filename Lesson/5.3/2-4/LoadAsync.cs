using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAsync : MonoBehaviour
{
    private AsyncOperation _operation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_operation!=null)
        {
            //加载进度
            Debug.Log("progress:"+_operation.progress);
            //是否加载成功
            Debug.Log("isDone:"+_operation.isDone);
        }
    }

    public void OnClickChange()
    {
        _operation = SceneManager.LoadSceneAsync("Levels");
        //加载完是否立即显示
        _operation.allowSceneActivation = false;
    }
}
