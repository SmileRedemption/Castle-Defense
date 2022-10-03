using System;
using Model;
using Spawner.GunfireSpawner;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GunfireSpawner))]
public class ShootButton : MonoBehaviour
{
    [SerializeField] private Button _shootButton;
    private GunfireSpawner _gunfireSpawner;

    private void Awake()
    {
        _gunfireSpawner = GetComponent<GunfireSpawner>();
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

    private void OnHeroDied()
    {
        _shootButton.interactable = false;
    }
}