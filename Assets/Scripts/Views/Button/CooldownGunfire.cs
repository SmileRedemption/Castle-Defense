using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ShootButton))]
public class CooldownGunfire : MonoBehaviour
{
    [SerializeField] private Image _reloadImage;
    [SerializeField] private Button _shootButton;
    [SerializeField] private float _cooldownDuration;

    private bool _isActiveButton = true;
    
    private void OnEnable()
    {
        _shootButton.onClick.AddListener(OnShootButtonClick);
    }

    private void Update()
    {
        _shootButton.interactable = _isActiveButton;
    }

    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(OnShootButtonClick);
    }

    private void OnShootButtonClick()
    {
        StartCoroutine(GunfireReloading(_cooldownDuration));
    }

    private IEnumerator GunfireReloading(float duration)
    {
        _reloadImage.fillAmount = 0;
        float elapsedTime = 0;

        StartCoroutine(WaitingToFill());

        while (elapsedTime < duration)
        {
            yield return null;
            var nextValue = Mathf.Lerp(0, 1, elapsedTime / duration);
            _reloadImage.fillAmount = nextValue;
            elapsedTime += Time.deltaTime;
        }

        _reloadImage.fillAmount = 1;
        
    }

    private IEnumerator WaitingToFill()
    {
        _isActiveButton = false;
        yield return new WaitUntil(() => (int) _reloadImage.fillAmount == 1);
        _isActiveButton = true;
    }
}
