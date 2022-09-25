using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    private Camera minimapCamera;
    // Start is called before the first frame update
    void Start()
    {
        minimapCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAdd()
    {
        minimapCamera.fieldOfView -= 2;
    }

    public void OnClickSubstruct()
    {
        minimapCamera.fieldOfView += 2;
    }
}
