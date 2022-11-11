using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSystem : MonoBehaviour
{
    public static AlarmSystem Instance;
    [Header("过渡速度")]
    public float turnSpeed = 3;
    // [HideInInspector]
    public Vector3 alarmPosition = new Vector3(1000, 1000, 1000);
    private Vector3 safePosition = new Vector3(1000, 1000, 1000);
    //警报灯
    private AlarmLight alarmLight;
    //住灯光
    private Light mainLight;
    //背景音乐
    private AudioSource normalAudio;

    private AudioSource panicAudio;
    //喇叭音乐
    private AudioSource[] sirensAudio;

    private void Awake()
    {
        Instance = this;
        //获取对象
        alarmLight = GameObject.FindWithTag(GameConst.ALARMLIGHT).GetComponent<AlarmLight>();
        mainLight = GameObject.FindWithTag(GameConst.MAINLIGHT).GetComponent<Light>();
        normalAudio = GetComponent<AudioSource>();
        panicAudio = transform.Find("secondmusic").GetComponent<AudioSource>();
        GameObject[] sirensObjects = GameObject.FindGameObjectsWithTag(GameConst.SIREN);
        sirensAudio = new AudioSource[sirensObjects.Length];
        for (int i = 0; i < sirensObjects.Length; i++)
        {
            sirensAudio[i] = sirensObjects[i].GetComponent<AudioSource>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //是否开启警报
        bool alarmOn = alarmPosition != safePosition;
        AlarmSystemOperator(alarmOn);
    }
    
    public void AlarmSystemOperator(bool alarmOn)
    {
        float alarmValue = alarmOn ? 1 : 0;
        alarmLight.alarmOn = alarmOn;
        //关闭主灯光
        mainLight.intensity = Mathf.Lerp(mainLight.intensity, 1-alarmValue, Time.deltaTime * turnSpeed);
        //过渡音乐
        normalAudio.volume = Mathf.Lerp(normalAudio.volume, 1-alarmValue, Time.deltaTime * turnSpeed);
        panicAudio.volume = Mathf.Lerp(panicAudio.volume, alarmValue, Time.deltaTime * turnSpeed);
        for (int i = 0; i < sirensAudio.Length; i++)
        {
            AudioSource sirenAudio = sirensAudio[i];
            sirenAudio.volume = Mathf.Lerp(sirenAudio.volume, alarmValue, Time.deltaTime * turnSpeed);
        }
    }
}
