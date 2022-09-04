using CNamespace;using UnityEngine;
class TestClass
{
    public static int num;
    public TestClass()
    {
        Debug.Log("构造"); 
    }

    ~TestClass()
    {
        Debug.Log("析构");
    }

    public static int GetNum()
    {
        return num;
    }

    public void Add(int a, int b)
    {
        
    }

    public void Add(int a)
    {
        
    }
}

class Shape
{
    protected int width;
    protected int height;

    public void setWidth(int w)
    {
        width = w;
    }

    public void setHeight(int h)
    {
        height = h;
    }
}

public interface IPainCost
{
    int getCost(int area);
}

class RectangleT: Shape,IPainCost {
    public int getCost(int area)
    {
        return area * 100;
    }

    public int getArea()
    {
        return width * height;
    }
}

abstract class APerson
{
    protected int age;
    abstract public string GetName();

    public int GetAge()
    {
        return age;
    }

    public virtual void SetAge(int a)
    {
        age = a;
    }
}

class Student : APerson
{
    protected string name;
    //覆盖子类方法
    public override string GetName()
    {
        return name;
    }

    public override void SetAge(int a)
    {
        Debug.Log("Student");
        age = a;
    }
}