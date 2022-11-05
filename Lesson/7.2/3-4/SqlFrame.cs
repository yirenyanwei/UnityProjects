using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class SqlFrame
{
    #region Single

    private static SqlFrame instance;

    public static SqlFrame GetInstance()
    {
        if (instance == null)
        {
            instance = new SqlFrame();
        }

        return instance;
    }

    protected SqlFrame()
    {
        
    }
    #endregion

    private string conStr;
    private SqliteConnection con;
    private SqliteCommand command;
    private SqliteDataReader reader;
    /**
     * 打开数据库
     */
    public void OpenDatabase(string databaseName)
    {
        if (!databaseName.EndsWith(".sqlite"))
        {
            databaseName = databaseName + ".sqlite";
        }
        conStr = getDataPath() + databaseName;
        //链接
        con = new SqliteConnection(conStr);
        con.Open();;
        //指令
        command = con.CreateCommand();

    }
    //关闭
    public void CloseDataBase()
    {
        if (reader!=null)
        {
            //关闭读取流
            reader.Close();
            reader = null;
        }
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
    
    //获取路径
    public string getDataPath()
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
    //非查询语句，返回受影响的行
    public int ExecuteNonQuery(string query)
    {
        command.CommandText = query;
        return command.ExecuteNonQuery();
    }

    public int Insert(string query)
    {
        return ExecuteNonQuery(query);
    }
    public int Delete(string query)
    {
        return ExecuteNonQuery(query);
    }
    public int Update(string query)
    {
        return ExecuteNonQuery(query);
    }

    public object Select(string query)
    {
        return ExecuteScalar(query);
    }

    public List<ArrayList> SelectMult(string query)
    {
        return ExecuteReader(query);
    }
    //返回单个数据
    public object ExecuteScalar(string query)
    {
        command.CommandText = query;
        return command.ExecuteScalar();
    }
    //返回多个数据
    public List<ArrayList> ExecuteReader(string query)
    {
        command.CommandText = query;
        reader = command.ExecuteReader();
        //存储多行多列 List<ArrayList>

        List<ArrayList> result = new List<ArrayList>();
        while (reader.Read())
        {
            ArrayList rowList = new ArrayList();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                rowList.Add(reader.GetValue(i));
            }
            result.Add(rowList);
        }
        reader.Close();
        return result;
    }
}
