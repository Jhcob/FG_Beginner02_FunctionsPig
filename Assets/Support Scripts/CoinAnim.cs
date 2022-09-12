using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CoinAnim : MonoBehaviour
{
    [SerializeField] private Transform coin;
    [SerializeField] private Transform pig;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform outPoint;
    [SerializeField] private GameObject ui;
    [SerializeField] private Color copper;
    [SerializeField] private Color silver;
    [SerializeField] private Color gold;

    private void Start()
    {
        coin.transform.position = endPoint.position;
        ui.SetActive(true);
    }

    public void AddCoin(int value)
    {
        coin.transform.position = startPoint.position;
        coin.GetComponent<MeshRenderer>().material.color = GetColor(value);
        ui.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(coin.DOMove(endPoint.position, 0.5f).SetEase(Ease.InCubic));
        sequence.Append(pig.DOShakeRotation(0.45f, strength: 20f, vibrato: 60));
        sequence.AppendInterval(0.4f);
        sequence.AppendCallback(() => ui.SetActive(true));
    }

    private Color GetColor(int value)
    {
        if (value <= 10)
            return copper;
        else if (value <= 25)
            return silver;

        return gold;
    }

    public void RotatePig()
    {
        ui.SetActive(false);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(pig.DOShakeRotation(0.45f, strength: 30f, vibrato: 30));
        sequence.AppendInterval(0.4f);
        sequence.AppendCallback(() => ui.SetActive(true));
    }
}
