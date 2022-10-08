using System.Collections;
using Spawner.GunfireSpawner;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(GunfireSpawner))]
public class ShootButton : MonoBehaviour
{
    [SerializeField] private Button _shootButton;
    [SerializeField] private float _cooldownDuration;

    private GunfireSpawner _gunfireSpawner;
    public float CooldownDuration { get; private set; }

    private void Awake()
    {
        _gunfireSpawner = GetComponent<GunfireSpawner>();
        CooldownDuration = _cooldownDuration;
    }

    private void OnEnable()
    {
        _shootButton.onClick.AddListener(OnShootButtonClick);
    }
    
    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(OnShootButtonClick);
    }

    private void OnShootButtonClick()
    {
        _gunfireSpawner.Shoot();
    }
    
    public void Add(UnityAction action)
    {
        _shootButton.onClick.AddListener(action);
    }

    public void Remove(UnityAction action)
    {
        _shootButton.onClick.RemoveListener(action);
    }

    public void TurnOff()
    {
        _shootButton.interactable = false;
    }

    public void TurnOn()
    {
        _shootButton.interactable = true;
    }

    public void OnHeroDied()
    {
        _shootButton.interactable = false;
    }

    public void RageOn(float speedUp)
    {
        StartCoroutine(DurationOfRageTime(7f));
    }

    private IEnumerator DurationOfRageTime(float duration)
    {
        CooldownDuration = 0;
        yield return new WaitForSeconds(duration);
        CooldownDuration = _cooldownDuration;
    }
}