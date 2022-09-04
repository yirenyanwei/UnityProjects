using UnityEngine;

public class TestEvent
{
        public delegate void MyDelegate(string key);
        //声明该事件的委托类型
        public event MyDelegate MyEvent;
        private string key;

        public TestEvent(string k)
        {
                key = k;
        }

        public void subscribe(MyDelegate dte)
        {
                MyEvent += dte;
        }

        public void publisher()
        {
                MyEvent(key);
        }
}

public class TestSubscribe
{
        public void onUpdate(string key)
        {
                Debug.Log("TestSubscribe Event");
        }
}