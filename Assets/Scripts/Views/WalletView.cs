using System;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class WalletView : View
    {
        private Text _countOfCoin;

        private void Awake()
        {
            _countOfCoin.text = "0";
        }

        public void SetAmount(int amount, int maxAmount)
        {
            _countOfCoin.text = $"{amount}";
            _countOfCoin.color = Color.Lerp(Color.white, Color.red, amount / maxAmount);
        }
    }
}