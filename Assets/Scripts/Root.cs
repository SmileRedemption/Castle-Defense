using System;
using Model;
using UnityEngine;
using Views;

public class Root : MonoBehaviour
{
    [SerializeField] private WizardView _wizardView;
    [SerializeField] private ArcherView _archerView;
    [SerializeField] private CastleView _castleView;

        
    private Wizard _wizard;
    private Archer _archer;
    private Castle _castle;
    public Wizard Wizard => _wizard;
    public Archer Archer => _archer;
    public Castle Castle => _castle;

    private void Awake()
    {
        _wizard = new Wizard(100, _wizardView.transform.position);
        _archer = new Archer(100, _archerView.transform.position);
        _castle = new Castle(200, 10, _castleView.transform.position);
    }
}