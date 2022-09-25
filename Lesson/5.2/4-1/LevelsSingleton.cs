
using System.Collections.Generic;

public class LevelsSingleton
{
    #region 单例
    //单例
    private static LevelsSingleton instance;
    //私有构造
    private LevelsSingleton()
    {
        //初始化
        LevelsStars = new Dictionary<int, int>();
    }
    //获取
    public static LevelsSingleton GetInstance()
    {
        if (instance==null)
        {
            instance = new LevelsSingleton();
        }

        return instance;
    }
    #endregion

    #region Properties
    //当前选择的关卡
    public int CurrentLevel = 0;
    //当前关获得的星星数
    public int CurrentStars = 0;
    //每一关获得的星星数
    public Dictionary<int, int> LevelsStars;

    public void SaveLevelData()
    {
        if (LevelsStars.ContainsKey(CurrentLevel))
        {
            if (LevelsStars[CurrentLevel]<CurrentStars)
            {
                LevelsStars[CurrentLevel] = CurrentStars;
            }
        }
        else
        {
            LevelsStars.Add(CurrentLevel, CurrentStars);
        }
    }

    public int GetLevelStarFromData()
    {
        int stars = 0;
        if (LevelsStars.ContainsKey(CurrentLevel))
        {
            stars = LevelsStars[CurrentLevel];
        }

        return stars;
    }
    public int GetLevelStarFromData(int levle)
    {
        int stars = 0;
        if (LevelsStars.ContainsKey(levle))
        {
            stars = LevelsStars[levle];
        }

        return stars;
    }

    #endregion
}
