using Model.Wallet;
using Views;

namespace Presenters
{
    public class WalletPresenter : IPresenter
    {
        private readonly Wallet _wallet;
        private readonly WalletView _walletView;

        public WalletPresenter(Wallet wallet, WalletView walletView)
        {
            _wallet = wallet;
            _walletView = walletView;
        }

        public void Enable()
        {
            _wallet.CoinsChanged += OnCoinsChanged; 
        }

        public void Disable()
        {
            _wallet.CoinsChanged -= OnCoinsChanged; 
        }
        
        private void OnCoinsChanged(int coins)
        {
            _walletView.SetAmount(coins, _wallet.MaxCoins);
        }
    }
}