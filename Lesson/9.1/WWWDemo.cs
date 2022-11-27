using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Video;

//下载相关 WWW已经弃用，用UnityWebRequest替代
public class WWWDemo : MonoBehaviour
{
    [Header("显示图片")]
    public RawImage rawImage;

    public Image image;

    private AudioSource audioSource;
    [Header("视频")]
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // StartCoroutine(DownLoadTest());
        // StartCoroutine(DownTexture());
        // StartCoroutine(DownMusic());
        // StartCoroutine(DownMovie());
        // StartCoroutine(DownloadFile());
        StartCoroutine(ReadFromResources());
    }
    //下载文字
    IEnumerator DownLoadTest()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://g.csdnimg.cn/side-toolbar/3.4/side-toolbar.js");
        //等待下载完毕
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            //文本
            Debug.Log(www.downloadHandler.text);
        }
        
    }
    //下载图片
    IEnumerator DownTexture()
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture("https://www.my-server.com/image.png");
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            Texture texture = ((DownloadHandlerTexture) www.downloadHandler).texture;
            texture.name = "downImage";
            //设置texture
            rawImage.texture = texture;
            rawImage.SetNativeSize();
            //设置image  将texture转化为sprite
            Rect rect = new Rect(0, 0, texture.width, texture.height);
            Sprite spr = Sprite.Create((Texture2D)texture, rect, Vector2.zero);
            image.sprite = spr;
            image.SetNativeSize();
        }
        else
        {
            Debug.Log("texture err");
        }
    }
    //下载音乐
    IEnumerator DownMusic()
    {
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("http://127.0.0.1:8888/music_panic.ogg", AudioType.OGGVORBIS);
        yield return www.SendWebRequest();
        if (www.result == UnityWebRequest.Result.Success)
        {
            AudioClip clip = ((DownloadHandlerAudioClip) www.downloadHandler).audioClip;
            Debug.Log(clip);
            audioSource.clip = clip;
            audioSource.Play();

        }
        else
        {
            Debug.Log("Down Music error");
        }
    }
    //下载视屏
    IEnumerator DownMovie()
    {
        videoPlayer.url = "http://127.0.0.1:8888/clashofkings.mp4";

        videoPlayer.isLooping = true;
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        
        videoPlayer.Play();

        yield return null;
    }
    
    //下载文件
    IEnumerator DownloadFile() {
        var uwr = new UnityWebRequest("http://127.0.0.1:8888/clashofkings.mp4", UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine(Application.dataPath+"/Resources/video", "clashofkings.mp4");
        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
        if (uwr.result != UnityWebRequest.Result.Success)
            Debug.LogError(uwr.error);
        else
            Debug.Log("File successfully downloaded and saved to " + path);
            
    }
    
    //从Resources加载资源
    IEnumerator ReadFromResources()
    {
        VideoClip video = Resources.Load<VideoClip>("video/clashofkings");
        if (video == null){
            Debug.Log("Video not found");
            yield return StartCoroutine(DownloadFile());
            yield return new WaitForEndOfFrame();
            video = Resources.Load<VideoClip>("video/clashofkings");
        }
        videoPlayer.clip = video;

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
