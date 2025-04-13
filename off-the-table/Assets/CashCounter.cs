using System;
using TMPro;
using UnityEngine;

public class CashCounter : MonoBehaviour
{
    [SerializeField] private Wallet wallet;
    [SerializeField] private TMP_Text textwindow;
    void Start()
    {
        textwindow = this.GetComponent<TMP_Text>();
        wallet.money = 5;
    }
    private void Update()
    {
        textwindow.SetText(wallet.money.ToString());        
    }
}
