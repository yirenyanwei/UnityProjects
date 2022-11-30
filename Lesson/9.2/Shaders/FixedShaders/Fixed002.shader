//固定管线着色器
Shader "MyShader/FixedShader/Fixed002"
{
    Properties
    {
        _DiffuseColor("漫反射颜色", Color) = (1,0,0,1)
        _AmbientColor("环境光颜色", Color) = (1,1,1,1)
        _SpecularColor("镜面反射颜色", Color) = (1,1,1,1)
        _Shininess("光泽度", Range(0,1)) = 0.5
    }
    SubShader
    {
        Pass
        {
            //开启顶点光照
            Lighting On
            //开启镜面反射
            SeparateSpecular On
            
            Material{
                //漫反射  偏暗 
                Diffuse[_DiffuseColor]
                //环境光
                Ambient[_AmbientColor]
                //镜面反射
                Specular[_SpecularColor]
                //光泽度
                Shininess[_Shininess]
            }
        }
    }
    Fallback "Deffuse"
}