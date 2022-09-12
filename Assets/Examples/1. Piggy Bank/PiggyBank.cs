using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBank : MonoBehaviour
{
    private int tenCentsCoins;
    private int twentyFiveCentsCoins;
    private int fiftyCentsCoins;
    
    public void AddATenCentCoin()
    {
        tenCentsCoins = tenCentsCoins + 1;
    }

    public void AddATwentyFiveCentsCoin()
    {
        twentyFiveCentsCoins = twentyFiveCentsCoins + 1;
    }

    public void AddAFiftyCentsCoin()
    {
        fiftyCentsCoins = fiftyCentsCoins + 1;
    }

    public int GetSavedAmount()
    {
        return tenCentsCoins * 10 + twentyFiveCentsCoins * 25 + fiftyCentsCoins * 50;
    }

    public void Empty()
    {
        tenCentsCoins = 0;
        twentyFiveCentsCoins = 0;
        fiftyCentsCoins = 0;
    }

    public string Extension()
    {
        return "This is the extension function.";
    }
}
