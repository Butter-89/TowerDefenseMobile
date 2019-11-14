using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyButton : MonoBehaviour
{
    public GameObject moneyImage;

    public void ToggleMoneyImage()
    {
        moneyImage.SetActive(!moneyImage.activeSelf);
    }
}
