using System;
using Model;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public class WizardSetup : Setup<Wizard, WizardView>
    {
        [SerializeField] private Root _root;
        [SerializeField] private HealthBar _healthBar;
        
        private Health _healthWizard;
        private HealthPresenter _healthPresenter;
        
        private void OnEnable()
        {
            Model = _root.Wizard;
            Presenter = new HeroPresenter(Model, View);
            
            _healthWizard = _root.Wizard.GetHealth();
            _healthPresenter = new HealthPresenter(_healthBar, _healthWizard);

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