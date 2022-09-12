using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private Store store;

    [SerializeField] private TextMeshProUGUI cash;
    [SerializeField] private TextMeshProUGUI actionQuantity;
    [SerializeField] private ProductOrganizer product1;
    [SerializeField] private ProductOrganizer product2;
    [SerializeField] private ProductOrganizer product3;
    [SerializeField] private Button p1Button;
    [SerializeField] private Button p2Button;
    [SerializeField] private Button p3Button;
    [SerializeField] private Button quantity1Button;
    [SerializeField] private Button quantityMinusButton;
    [SerializeField] private Button quantityPlusButton;
    [SerializeField] private Button quantityDoublePlusButton;
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    [SerializeField] private GameObject prompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Button promptButton;
    [SerializeField] private Button closeButton;

    int quantity = 1;
    int productIndex = 1;

    private void Start()
    {
        SetupButtons();
        UpdateStore();
        UpdateSelection();
    }

    private void SetupButtons()
    {
        p1Button.onClick.AddListener(() => SetProduct(1));
        p2Button.onClick.AddListener(() => SetProduct(2));
        p3Button.onClick.AddListener(() => SetProduct(3));

        quantity1Button.onClick.AddListener(() => SetQuantity(1));
        quantityMinusButton.onClick.AddListener(() => SetQuantity(quantity - 1));
        quantityPlusButton.onClick.AddListener(() => SetQuantity(quantity + 1));
        quantityDoublePlusButton.onClick.AddListener(() => SetQuantity(quantity + 5));

        buyButton.onClick.AddListener(Buy);
        sellButton.onClick.AddListener(Sell);
        promptButton.onClick.AddListener(() => ShowPrompt(store.Extension()));
        closeButton.onClick.AddListener(() => prompt.SetActive(false));
    }

    private void SetProduct(int index)
    {
        productIndex = index;
        UpdateSelection();
    }

    private void SetQuantity(int newQuantity)
    {
        quantity = newQuantity;
        if (quantity <= 0)
        {
            actionQuantity.color = Color.red;
            actionQuantity.DOColor(Color.black, 0.3f);
            quantity = 1;
        }
        if (quantity > 20)
        {
            actionQuantity.color = Color.red;
            actionQuantity.DOColor(Color.black, 0.3f);
            quantity = 20;
        }
        UpdateSelection();
    }

    private void UpdateSelection()
    {
        p1Button.interactable = productIndex != 1;
        p2Button.interactable = productIndex != 2;
        p3Button.interactable = productIndex != 3;
        actionQuantity.text = quantity + "";
    }

    private void UpdateStore()
    {
        product1.Organize(store.GetQuantityByProduct(1));
        product2.Organize(store.GetQuantityByProduct(2));
        product3.Organize(store.GetQuantityByProduct(3));

        cash.text = "$" + store.GetMoney();
    }

    private void Buy()
    {
        if (store.CanGetProduct(productIndex, quantity))
        {
            store.PurchaseProduct(productIndex, quantity);
            UpdateStore();
        }
        else if (store.GetSpaceLeftForProduct(productIndex) < quantity)
        {
            ShowPrompt("There's not enough space for this purchase.");
        }
        else
        { 
            ShowPrompt("There's not enough money for this purchase.");
        }
    }

    private void Sell()
    {
        if (store.CanSellProduct(productIndex, quantity))
        {
            store.SellProduct(productIndex, quantity);
            UpdateStore();
        }
        else
        {
            ShowPrompt("There's not enough units for this sale.");
        }
    }

    private void ShowPrompt(string content)
    {
        promptText.text = content;
        prompt.SetActive(true);
    }
}
