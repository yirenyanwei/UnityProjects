delegate int NumberChanger(int n);
public class TestDelegate
{
    private static int num = 0;

    public static int AddNum(int n)
    {
        num += n;
        return num;
    }

    public static int MultNum(int n)
    {
        num *= n;
        return num;
    }

    public static int getNum()
    {
        return num;
    }
}