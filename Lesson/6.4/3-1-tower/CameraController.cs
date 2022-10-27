using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float hor, ver;
    [Header("x/z的边界")]
    public Vector2 startLimit = new Vector2(20, 0);

    public Vector2 endLimit = new Vector2(40, 35);
    [Header("移动速度")]
    public float moveSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        Vector3 curPos = transform.position + new Vector3(hor, 0, ver) * Time.deltaTime * moveSpeed;
        float x = Mathf.Clamp(curPos.x, startLimit.x, endLimit.x);
        float z = Mathf.Clamp(curPos.z, startLimit.y, endLimit.y);
        transform.position = new Vector3(x, curPos.y, z);
    }
}
