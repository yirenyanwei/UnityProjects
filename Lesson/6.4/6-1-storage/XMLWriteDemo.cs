using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class XMLWriteDemo : MonoBehaviour
{
    private Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        /**
         <?xml>
         <GameObject name="Cube">
            <Rigidbody>
                <Mass>1</Mass>
            </Rigidbody>
         </GameObject>
         */
        //实例化document文档
        XmlDocument doc = new XmlDocument();
        //头文本节点
        // XmlNode headNode = doc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
        XmlDeclaration headNode = doc.CreateXmlDeclaration("1.0", "UTF-8", "");
        doc.AppendChild(headNode);
        //GameObject
        XmlElement GameObject_el = doc.CreateElement("GameObject");
        doc.AppendChild(GameObject_el);
        //设置属性
        GameObject_el.SetAttribute("name", gameObject.name);
        //属性2  另一种创建方式
        XmlAttribute name_att = doc.CreateAttribute("name2");
        name_att.Value = "Object";
        GameObject_el.SetAttributeNode(name_att);
        
        //刚体
        XmlElement Rigidbody_el = doc.CreateElement("Rigidbody");
        XmlElement Mass_el = doc.CreateElement("Mass");
        //设置文本
        Mass_el.InnerText = rig.mass.ToString();
        Rigidbody_el.AppendChild(Mass_el);
        GameObject_el.AppendChild(Rigidbody_el);
        
        //存储到Assets文件夹下
        doc.Save(Application.dataPath+"/obj.xml");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
