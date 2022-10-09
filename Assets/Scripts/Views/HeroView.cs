using System;
using System.Collections;
using Model.Score;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Animator))]
    public abstract class HeroView : View
    {
        [SerializeField] private ShootButton _shootButton;
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public event Action Relieved;
        
        public void Rage(float speedUp)
        {
            _shootButton.RageOn(speedUp);
        }

        public void RestoreHealth()
        {
            
        }
        
        public override void Died()
        {
            _shootButton.OnHeroDied();
            StartCoroutine(WaitingToRelieve());
            TurnOff();
        }

        private void Relieve()
        {
            Relieved?.Invoke();
            _shootButton.OnHeroRelieved();
            TurnOn();
        }

        private void TurnOff()
        {
            _animator.Play("Die");
        }

        private void TurnOn()
        {
            _animator.Play("IDLE");
        }
        
        private IEnumerator WaitingToRelieve()
        {
            yield return new WaitForSeconds(10f);
            Relieve();
        }
    }
}