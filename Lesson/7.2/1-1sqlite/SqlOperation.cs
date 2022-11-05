using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
public class SqlOperation : MonoBehaviour
{
    private string databasePath;//路径

    private SqliteConnection con;//链接对象
    //数据库指令
    private SqliteCommand command;
    // Start is called before the first frame update
    void Start()
    {
        //仅限编辑器使用 Assets下
        Debug.Log(Application.dataPath);
        //流路径 各平台都能用 pc平台
        Debug.Log(Application.streamingAssetsPath);
        //持久化路径 各平台都有 移动平台
        Debug.Log(Application.persistentDataPath);

        databasePath = getDataPath() + "StudentsDB.sqlite";
        //实例化数据库连接对象，并绑定数据库路径
        con = new SqliteConnection(databasePath);
        //打开链接
        con.Open();
        //创建指令
        command = con.CreateCommand();
        //执行sql

        //sql执行的三个方法
        command.CommandText = "Insert Into StudentBaseDB Values('1', 'xiaoming', 20, '山东')";
        // 1 返回受影响的行数  【增、删、改】
        // int rows = command.ExecuteNonQuery();
        // Debug.Log("rows:"+rows.ToString());
        
        //sql语句
        command.CommandText = "Select Name from StudentBaseDB Where ID=0";
        //2 返回object  返回查询到的第一行第一列的数据结果 用于查询单个数据
        object val = command.ExecuteScalar();
        Debug.Log("val:"+val);
        
        command.CommandText = "Select * from StudentBaseDB";
        //3 返回reader 查询多个数据
        SqliteDataReader reader = command.ExecuteReader(); 
        // reader.Read();//读取下一行，若没有下一行则返回false
        while (reader.Read())
        {
            Debug.Log("------------");
            for (int i = 0; i < reader.FieldCount; i++)
            {
                // GetName 列名  GetValue 列的值
                Debug.Log(reader.GetName(i)+"-"+reader.GetValue(i));
            }
        }
        reader.Close();//关闭reader
        
        
    }
    //获取路径
    string getDataPath()
    {
        string path;
#if UNITY_EDITOR
        path = "Data Source = " + Application.streamingAssetsPath + "/";
#elif UNITY_ANDROID
        path = "URL=file:" + Application.persistentDataPath + "/";
#elif UNITY_IOS
        path = "Data Source = " + Application.persistentDataPath + "/";
#endif
        return path;
    }
    
    //应用程序关闭调用一次
    private void OnApplicationQuit()
    {
        if (command != null)
        {
            //释放command
            command.Dispose();
            command = null;
        }
        if (con != null)
        {
            //关闭连接
            con.Close();
            con = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
