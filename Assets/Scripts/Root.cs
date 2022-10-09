using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Score;
using Model.Spells;
using Presenters;
using UnityEngine;
using Views;

public class Root : MonoBehaviour
{
    [SerializeField] private WizardView _wizardView;
    [SerializeField] private ArcherView _archerView;
    [SerializeField] private CastleView _castleView;
    [SerializeField] private Wave[] _waves;

    private bool _isInit;

    public Wizard Wizard { get; private set; }
    public Archer Archer { get; private set; }
    public Castle Castle { get; private set; }
    public HealthSpell HealthSpell { get; private set; }
    public RageSpell RageSpell { get; private set; }
    public Score Score { get; private set; }
    public Wave[] Waves => _waves;

    public void Init()
    {
        if (_isInit)
            return;
        
        Wizard = new Wizard(_wizardView.Position);
        Archer = new Archer(_archerView.Position);
        Castle = new Castle(_castleView.Position);
        HealthSpell = new HealthSpell();
        RageSpell = new RageSpell();
        Score = new Score();

        _isInit = true;
    }

    public IEnumerable<Hero> GetHeroes()
    {
        return new Hero[] {Wizard, Archer};
    }
}