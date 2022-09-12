using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductOrganizer : MonoBehaviour
{
    private int quantity;
    [SerializeField] private float space;
    [SerializeField] private int rows = 3;
    [SerializeField] private int columns = 3;

    private ProductBox[] products;
    private Transform start;

    private void Awake()
    {
        start = transform;
        products = transform.GetComponentsInChildren<ProductBox>();    
    }

    public void Organize(int amountOfProducts)
    {
        quantity = amountOfProducts;

        for (int i = 0; i < products.Length; i++)
        {
            products[i].gameObject.SetActive(i < quantity);
        }

        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                products[row * columns + column].transform.position = transform.position + new Vector3(column * space, row * space, 0);
            }
        }
    }
}
