using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UGUIBehaviourScript : MonoBehaviour, IPointerDownHandler
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(this.OnButtonClic2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        print("Click Button");
    }

    public void OnButtonClic2()
    {
        print("Click Button2");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("onclicked image");
    }

    public void OnValueChange(bool value)
    {
        print(String.Format("OnValueChange-"+ (value?"on":"off")));
    }
}
