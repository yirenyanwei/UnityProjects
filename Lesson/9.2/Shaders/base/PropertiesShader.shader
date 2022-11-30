Shader "MyShader/Base/PropertiesShader"
{
    //ShaderLab
    Properties 
    {
        //属性名(面板显示，类型)=值
        //浮点数
        _FloatValue("浮点数", float) = 1
        //范围 常用
        _RangeValue("范围浮点数", Range(0, 100)) = 50
        //四维数
        _VectorValue("四维数", Vector) = (1,1,1,1)
        //颜色 常用
        _ColorValue("颜色", Color) = (1,0,0,1)
        //二阶贴图(2的次方) 常用
        _Texture2d("二阶贴图", 2D) = "red"{}
        //非二阶贴图
        _TextureRect("非二阶贴图", Rect) = ""{}
        //立方体贴图 六个面
        _TextureCube("立方体贴图", Cube) = ""{}
    }
    SubShader
    {
        Pass
        {
        }
    }
    Fallback "Diffuse"
}