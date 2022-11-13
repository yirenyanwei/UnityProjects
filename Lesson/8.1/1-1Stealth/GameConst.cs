using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConst
{
    #region Game Tags

    public const string MAINLIGHT = "MainLight";
    public const string ALARMLIGHT = "AlarmLight";
    public const string SIREN = "Siren";
    public const string PLAYER = "Player";
    public const string ENEMY = "Enemy";

    #endregion

    #region Virtual Button & Axis

    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string SNEAK = "Sneak";
    public const string SHOUT = "Shout";
    public const string SWITCH = "Switch";

    #endregion

    #region Animation

    public static int SPEED_PARAM = Animator.StringToHash("Speed");
    public static int SNEAK_PARAM = Animator.StringToHash("Sneak");
    public static int SHOUT_PARAM = Animator.StringToHash("Shout");
    public static int LOCOMOTION_STATE = Animator.StringToHash("Locomotion");
    public static int DOOROPEN_PARAM = Animator.StringToHash("DoorOpen");
    #endregion

    #region Static Constructor

    static GameConst()
    {
        //调用静态变量的时候会调用
        Debug.Log("静态构造");
    }

    #endregion

    #region Game Params

    public const float WATCH_OFFSET = 0f;

    #endregion
}
