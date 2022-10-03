using System;
using Model;
using Presenters;
using UnityEngine;
using Views;

namespace Setup
{
    public abstract class Setup<TModel, TView>   : MonoBehaviour
        where TModel : Transformable where TView : View
    {
        [SerializeField] protected TView View;
        
        protected TModel Model;
        protected IPresenter Presenter;
        protected IUpdateable Updateable = null;

        private void Update()
        {
            Updateable?.Update(Time.deltaTime);
        }
    }
}