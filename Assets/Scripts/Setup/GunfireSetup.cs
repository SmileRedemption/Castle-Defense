using System;
using Model;
using Presenters;
using Views;

namespace Setup
{
    public class GunfireSetup : Setup<Gunfire, GunfireView>
    {
        public void Init(EnemyView enemyView, GunfireView gunfireView)
        {
            Model = new Gunfire(20, 5, enemyView.Position, transform.position, 1);
            View = gunfireView;
            Presenter = new GunfirePresenter(Model, View);
            
            if (Model is IUpdateable updateable)
                Updateable = updateable;

            enabled = true;
        }

        private void OnEnable()
        {
            Presenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
        }
    }
}