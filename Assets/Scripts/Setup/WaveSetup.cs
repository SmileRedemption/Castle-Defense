using System;
using Model;
using Presenters;
using UnityEngine;

namespace Setup
{
    public class WaveSetup : Setup<Wave, WaveBar>
    {
        public void Init(Wave wave)
        {
            Model = wave;
            Presenter = new WavePresenter(Model, View);

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