//固定管线着色器
Shader "MyShader/FixedShader/Fixed001"
{
    Properties
    {
        _MainColor("颜色", Color) = (1,0,0,1)
    }
    SubShader
    {
        Pass
        {
            //固定颜色
//            Color(1,0,0,1)
            //可变颜色
            Color[_MainColor]
        }
    }
    Fallback "Deffuse"
}