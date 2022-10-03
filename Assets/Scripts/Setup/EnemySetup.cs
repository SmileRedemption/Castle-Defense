using System;
using Model;
using Model.Enemy;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class EnemySetup : Setup<Enemy, EnemyView>
    {
        [SerializeField] private HealthBar _healthBar;

        private Health _healthGolem;
        private HealthPresenter _healthPresenter;

        private void Awake()
        {
            enabled = false;
        }

        public void Init(ITarget target)
        {
            Model = new Golem(5, target, View.transform.position);
            Presenter = new EnemyPresenter(Model, View);

            _healthGolem = Model.GetHealth();
            _healthPresenter = new HealthPresenter(_healthBar, _healthGolem);
                
            if (Model is IUpdateable updateable)
                Updateable = updateable;

            enabled = true;
        }

        private void OnEnable()
        {
            Presenter.Enable();
            _healthPresenter.Enable();
        }

        private void OnDisable()
        {
            Presenter.Disable();
            _healthPresenter.Disable();
        }
    }
}