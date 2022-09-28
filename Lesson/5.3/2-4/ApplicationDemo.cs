using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //允许在后台运行
        Application.runInBackground = true;
        //表示工程下的Assets，仅限在Unity中运行使用  Assets
        Debug.Log(Application.dataPath);
        //IO流路径，不同平台路径不同  Assets/StreamingAssets
        Debug.Log(Application.streamingAssetsPath);
        //沙盒路径，持久化路径  平台不同，路径不同
        Debug.Log(Application.persistentDataPath);
        //截屏
        // ScreenCapture.CaptureScreenshot("TempPic.png");
        //打开网页
        // Application.OpenURL("https://www.baidu.com");
        //关闭程序
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
