using System;

namespace Model.Wallet
{
    public class Wallet
    {
        public int MaxCoins { get; private set; }
        public int Coins { get; private set; }

        public event Action<int> CoinsChanged;

        public void AddCoins(int countOfCoin)
        {
            if (Coins + countOfCoin > MaxCoins)
                throw new InvalidOperationException();

            Coins += countOfCoin;
            CoinsChanged?.Invoke(Coins);
        }
    }
}