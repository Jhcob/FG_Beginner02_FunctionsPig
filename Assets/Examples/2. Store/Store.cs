using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private float initialMoney;
    [SerializeField] private Product product1;
    [SerializeField] private Product product2;
    [SerializeField] private Product product3;

    private float money;

    private void Awake()
    {
        money = initialMoney;
        Initialize();
    }

    public float GetMoney()
    {
        return money;
    }

    public void Initialize()
    {
        product1.SetShelfLimit(8);
        product2.SetShelfLimit(5);
        product3.SetShelfLimit(14);

        product1.SetPrices(5.5f, 6f);
        product2.SetPrices(8.5f, 10f);
        product3.SetPrices(10f, 15f);
    }

    private Product GetProductByIndex(int productIndex)
    {
        if (productIndex == 1)
        {
            return product1;
        }

        if (productIndex == 2)
        {
            return product2;
        }

        return product3;
    }

    public int GetQuantityByProduct(int productIndex)
    {
        return GetProductByIndex(productIndex).GetCurrentAmount();
    }

    public int GetSpaceLeftForProduct(int productIndex)
    {
        return GetProductByIndex(productIndex).SpaceLeft();
    }

    public bool CanGetProduct(int productIndex, int quantity)
    {
        Product product = GetProductByIndex(productIndex);
        float moneyNeeded = product.GetWarehousePrice() * quantity;
        return money >= moneyNeeded && product.SpaceLeft() >= quantity;
    }

    public void PurchaseProduct(int productIndex, int quantity)
    { 
        Product product = GetProductByIndex(productIndex);
        float moneyNeeded = product.GetWarehousePrice() * quantity;
        product.StockUp(quantity);
        money -= moneyNeeded;
    }

    public bool CanSellProduct(int productIndex, int quantity)
    {
        Product product = GetProductByIndex(productIndex);
        return product.HasEnough(quantity);
    }

    public void SellProduct(int productIndex, int quantity)
    { 
        Product product = GetProductByIndex(productIndex);
        float moneyEarned = product.GetCustomerPrice() * quantity;
        product.SellAmount(quantity);
        money += moneyEarned;
    }

    public int GetTotalUnitsSold()
    {
        return product1.GetAmountUnitsSold() + product2.GetAmountUnitsSold() + product3.GetAmountUnitsSold();
    }

    public int MostSold()
    {
        if (product1.GetAmountUnitsSold() > product2.GetAmountUnitsSold() && product1.GetAmountUnitsSold() > product3.GetAmountUnitsSold())
        {
            return 1;
        }
        else if (product2.GetAmountUnitsSold() > product1.GetAmountUnitsSold() &&
                 product2.GetAmountUnitsSold() > product3.GetAmountUnitsSold())
        {
            return 2;
        }
        else ;
        {
            return 3;
        }
    }

    public string Extension()
    {
        
        return "The most sold item is " + MostSold();
    }
}
