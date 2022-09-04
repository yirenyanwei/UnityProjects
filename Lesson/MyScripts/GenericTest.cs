using UnityEngine;


//泛型委托
public delegate T NumberChangeGeneric<T>(T t);
//泛型类
public class GenericTest<T>
{
        private T tIndex;
        //泛型方法
        public void Print<R>(R r)
        { 
                Debug.Log(r);
        }
}