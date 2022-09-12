using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBank : MonoBehaviour
{
    private int tenCentsCoins;
    private int twentyFiveCentsCoins;
    private int fiftyCentsCoins;
    private double taxes = 0.25;
    
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

    public int GetAmountOfCoins()
    {
        return tenCentsCoins + fiftyCentsCoins + twentyFiveCentsCoins;
    }

    public double SavedAfterTaxes()
    {
        return GetSavedAmount() - GetSavedAmount() * taxes;
    }
        
    public string Extension()
    {
        return "The saved amount after taxes is " + SavedAfterTaxes();
    }
}
