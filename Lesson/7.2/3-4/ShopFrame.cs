using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopFrame : SqlFrame
{
    #region Single

    private static ShopFrame instance;

    public static new ShopFrame GetInstance()
    {
        if (instance == null)
        {
            instance = new ShopFrame();
        }

        return instance;
    }

    protected ShopFrame()
    {
        
    }
    #endregion

    public void BuyEquip(string equipName)
    {
        
    }

    public void SellEquip(string equipName)
    {
        
    }
}
