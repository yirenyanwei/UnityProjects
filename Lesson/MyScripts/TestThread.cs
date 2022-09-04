using UnityEngine;
using System.Threading;
public class TestThread
{
        public static void CallBack()
        {
                Debug.Log("CallBack");
        }

        public static void Start()
        {
                ThreadStart childref = new ThreadStart(CallBack);
                Thread cthread = new Thread(childref);
                cthread.Start();
                //暂停主线程
                Thread.Sleep(2000);
                cthread.Abort();//终止线程
        }
}