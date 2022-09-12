using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : MonoBehaviour
{
    private float priceFromWarehouse;
    private float priceToCostumer;
    private int currentAmount;
    private int shelfLimit;
    public int unitsSold;

    public void SetShelfLimit(int limit)
    {
        shelfLimit = limit;
    }

    public void SetPrices(float warehouse, float customer)
    {
        priceFromWarehouse = warehouse;
        priceToCostumer = customer;
    }

    public float GetWarehousePrice()
    {
        return priceFromWarehouse;
    }

    public float GetCustomerPrice()
    {
        return priceToCostumer;
    }

    public int GetCurrentAmount()
    {
        return currentAmount;
    }

    public bool HasEnough(int quantity)
    {
        return currentAmount >= quantity;
    }

    public void SellAmount(int quantity)
    {
        currentAmount -= quantity;
        unitsSold += quantity;
    }

    public int GetAmountUnitsSold()
    {
        return unitsSold;
    }

    public int SpaceLeft()
    {
        return shelfLimit - currentAmount;
    }

    public void StockUp(int quantity)
    {
        currentAmount += quantity;
    }
}
