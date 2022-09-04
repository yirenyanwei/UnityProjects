using CNamespace;
using UnityEngine;
using System;
public class TestBase
{
    public TestBase()
    {
        /*值类型*/
        bool bType = true;
        byte btType = 128;
        char cType = 'a';
        float fType = 10.0f;
        double dType = 20.0;
        short sType = 10;
        int iType = 20;
        long lType = 30;
        ushort usType = 10;
        Debug.Log(btType);
        
        /*引用类型*/
        //对象
        object obj;
        obj = 100;//装箱
        //动态类型
        dynamic d = 20;//类型检查实在运行时
        //字符串
        string str = "123";
        string str1 = @"hello <script>
        </script>
        ";//不会转义
        //用户自定义类型 class interface delegate
        
        /*指针类型*/
        // int* iptr;
        
        /*类型转换*/
        Debug.Log(iType.ToString());

        /*常量*/
        const string cstType = "hello";

        for (int i = 0; i < 100; i++)
        {
            Debug.Log(i);
        }

        int[] arr = new int[] {1, 2, 3};
        foreach (var item in arr)
        {
            Debug.Log(item);
        }
        
        /*封装*/
        Rectangle rectangle = new Rectangle(10, 20);
        rectangle.Display();
        
        /*按引用传递参数*/
        int temp_a = 1;
        int temp_b = 1;
        rectangle.ChangeValue(ref temp_a, temp_b);
        Debug.Log(String.Format("{0}-{1}", temp_a, temp_b));
        /*按输出产地参数*/
        int temp_c = 1;
        rectangle.GetValue(out temp_c);
        Debug.Log(temp_c);
        
        /*单?  与  ??*/
        double? num1 = null;//正常值范围基础上多了一个null
        double num2 = 100;
        double num3 = num1 ?? num2;//判断为null返回后边值
        Debug.Log(num3);
        
        
        /*Array 引用类型*/
        int[] iArr = {1, 2, 3, 4, 5};
        for (int i = 0; i < iArr.Length; i++)
        {
            Debug.Log(iArr[i]);
        }

        int[,] mulArr = new int[3,4];
        for (int i = 0; i < mulArr.GetLength(0); i++)
        {
            for (int j = 0; j < mulArr.GetLength(1); j++)
            {
                Debug.Log(String.Format("{0}-{1}", i, j));
            }
        }

        int[][] jcArr = new int[2][]{new int[]{1,2}, new int[]{3,4,5}};
        for (int i = 0; i < jcArr.Length; i++)
        {
            for (int j = 0; j < jcArr[i].Length; j++)
            {
                Debug.Log(String.Format("{0}-{1}", i, j));
            }
        }
        
        /*字符串 string 是System.String的别名*/
        string fStr, lStr;
        fStr = "hello";
        lStr = "world";
        string fullName = fStr + " " + lStr;
        char[] cStr = new char[] {'H', 'e', 'l'};
        string myName = new string(cStr);
        
        /*结构体 Struct 值类型*/
        Books book1;
        book1.id = "123";
        book1.name = "xiaoming";
        Debug.Log(book1);//全部初始化完才能使用
        
        /*枚举*/
        rectangle.ConsoleEnum();
        
    }
}