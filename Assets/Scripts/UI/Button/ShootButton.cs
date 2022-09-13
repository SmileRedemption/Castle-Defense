using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour
{
    [SerializeField] private Hero _hero;
    [SerializeField] private Button _shootButton;

    private void OnEnable()
    {
        _shootButton.onClick.AddListener(OnShootButtonClick);
        _hero.Died += OnHeroDied;
    }


    private void OnDisable()
    {
        _shootButton.onClick.RemoveListener(OnShootButtonClick);
        _hero.Died -= OnHeroDied;
    }

    private void OnShootButtonClick()
    {
        _hero.Attack();
    }

    private void OnHeroDied()
    {
        _shootButton.interactable = false;
    }
}