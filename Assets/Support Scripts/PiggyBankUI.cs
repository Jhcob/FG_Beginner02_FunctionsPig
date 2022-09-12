using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PiggyBankUI : MonoBehaviour
{
    [SerializeField] private PiggyBank piggyBank;
    [SerializeField] private CoinAnim anim;
    [SerializeField] private Button ten;
    [SerializeField] private Button twentyFive;
    [SerializeField] private Button fifty;
    [SerializeField] private Button savedButton;
    [SerializeField] private Button clearButton;
    [SerializeField] private GameObject savedScreen;
    [SerializeField] private Button close;
    [SerializeField] private TextMeshProUGUI savedAmount;
    [SerializeField] private GameObject prompt;
    [SerializeField] private TextMeshProUGUI promptText;
    [SerializeField] private Button promptButton;
    [SerializeField] private Button closeButton;

    private void Start()
    {
        ten.onClick.AddListener(AddTen);
        twentyFive.onClick.AddListener(AddTwentyFive);
        fifty.onClick.AddListener(AddFifty);
        close.onClick.AddListener(() => savedScreen.SetActive(false));
        savedButton.onClick.AddListener(ShowSavedAmount);
        clearButton.onClick.AddListener(ClearPig);

        promptButton.onClick.AddListener(() => ShowPrompt(piggyBank.Extension()));
        closeButton.onClick.AddListener(() => prompt.SetActive(false));
    }

    public void AddTen()
    {
        piggyBank.AddATenCentCoin();
        anim.AddCoin(10);
    }

    public void AddTwentyFive()
    {
        piggyBank.AddATwentyFiveCentsCoin();
        anim.AddCoin(25);
    }

    public void AddFifty()
    {
        piggyBank.AddAFiftyCentsCoin();
        anim.AddCoin(50);
    }

    public void ShowSavedAmount()
    {
        savedAmount.text = "You have saved " + piggyBank.GetSavedAmount() + " cents";
        savedScreen.SetActive(true);
    }

    public void ClearPig()
    {
        anim.RotatePig();
        piggyBank.Empty();
    }

    private void ShowPrompt(string content)
    {
        promptText.text = content;
        prompt.SetActive(true);
    }
}
