using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour, IInteractive
{
    [SerializeField] private Counter _counter;
    [SerializeField] private GlobalUpgradeModifier _globalUpgrade;
    [SerializeField] private double _cowCount;
    [SerializeField] private Cow _cow;

    [SerializeField] private double _farmProduction;
    [SerializeField] private double _farmMultiplier;
    [SerializeField] private double _employeeCount;
    [SerializeField] private double _employeeEffectiveness;


    private void Start()
    {
        InvokeRepeating("AutoFarmProduction", 0.0f, 1.0f);
    }

    public void OnClick()
    {
        FarmProduction();
    } 
    
    public void Interact()
    {

    }

    private void FarmProduction()
    {
        for (double i = 0; i < _cowCount; i++ )
        {
            double produceAmount = _cow.GetProduction() * CalculateFarmProductivity() * _globalUpgrade.GetGlobalCowMultiplier() * _globalUpgrade.GetGlobalMultiplier(); ;
            _counter.AddMilk(produceAmount);
        }
    }
    private void AutoFarmProduction()
    {
        _farmProduction = 0;
        for (double i = 0; i < _cowCount; i++ )
        {
            double produceAmount = _cow.GetProduction() * CalculateFarmProductivity() * _globalUpgrade.GetGlobalCowMultiplier() * _globalUpgrade.GetGlobalMultiplier(); ;
            _counter.AddMilk(produceAmount);
            _farmProduction += produceAmount;
        }
        _counter.AddMilkPerSec(_farmProduction);
    }

    private double CalculateFarmProductivity()
    {
        return _employeeCount * _employeeEffectiveness *  _farmMultiplier;
    }

    public double GetFarmProduction()
    {
        return _farmProduction;
    }
}
