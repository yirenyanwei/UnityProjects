using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Star : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public int CurrentIdx;
    public StartsControl Control;
    private Image currentImg;
    // Start is called before the first frame update
    void Start()
    {
        currentImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Virtual Axios: MouseX MouseY
        //鼠标在水平方向的移动 速度
        //正值表示从左到右 负值表示从右到左
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mousex)>Mathf.Abs(mousey))
        {
            if (mousex>0)
            {
                Control.SetStarsAlpha(0, CurrentIdx, 1);
            }else if (mousex<0)
            {
                // Control.SetStarsAlpha(CurrentIdx, 2, 0);
            }
        }
        else
        {
            Control.SetStarsAlpha(0, CurrentIdx, 1);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        float mousex = Input.GetAxis("Mouse X");
        float mousey = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(mousex) > Mathf.Abs(mousey) && mousex<0)
        {
            //hide
            Control.SetStarsAlpha(CurrentIdx, 2, 0);
        }
        // SetCurrentAlpha(0);
    }

    public void SetCurrentAlpha(float alpha)
    {
        Color color = currentImg.color;
        currentImg.color = new Color(color.r, color.g, color.b, alpha);
    }
}
