
public class LevelsSingleton
{
    //单例
    private static LevelsSingleton instance;
    //私有构造
    private LevelsSingleton()
    {
        
    }
    //获取
    public LevelsSingleton GetInstance()
    {
        if (instance==null)
        {
            instance = new LevelsSingleton();
        }

        return instance;
    }
}
