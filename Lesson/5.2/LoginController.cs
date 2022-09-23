using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour
{
    public TMP_InputField UserNameInput;

    public TMP_InputField PassWordInput;

    public Button LoginBtn;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = transform as RectTransform;
        LoginBtn.onClick.AddListener(OnLoginClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLoginClick()
    {
        Debug.Log(UserNameInput.text+"--"+PassWordInput.text);
    }
}
