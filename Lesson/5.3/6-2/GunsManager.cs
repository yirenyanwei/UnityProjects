using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsManager : MonoBehaviour
{
    //所有武器
    private WeaponController[] weapons;
    //当前武器
    private int currentWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        weapons = new WeaponController[transform.childCount];
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = transform.GetChild(i).GetComponent<WeaponController>();
            weapons[i].gameObject.SetActive(false);
        }
        //当前
        currentWeapon = 0;
        weapons[currentWeapon].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //开火
            weapons[currentWeapon].Fire();
        }else if (Input.GetKeyDown(KeyCode.R))
        {
            //换弹
            weapons[currentWeapon].Reload();
        }else if (Input.GetKeyDown(KeyCode.Q))
        {
            //换枪
            weapons[currentWeapon].gameObject.SetActive(false);
            currentWeapon++;
            currentWeapon %= weapons.Length;
            weapons[currentWeapon].gameObject.SetActive(true);
        }
    }
}
