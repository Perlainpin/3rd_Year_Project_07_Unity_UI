using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private double _milkCount;
    [SerializeField] private double _milkLastSecond;
    [SerializeField] private double _milkThisSecond;

    private void Start()
    {
        _milkLastSecond = 0;
        _milkThisSecond = 0;
    }
    public double GetMilk()
    {
        return _milkCount;
    }    
    
    public double GetMilkPerSec()
    {
        if (_milkLastSecond > _milkThisSecond) return _milkLastSecond;

        if (_milkLastSecond - _milkThisSecond != 0)
            _milkLastSecond = _milkThisSecond;
        _milkThisSecond = 0;
        return _milkLastSecond;

    }

    public void AddMilk(double milk)
    {
        _milkCount += milk;
    }
    
    public void SellMilk(double milk)
    {
        _milkCount -= milk;
    }
    
    public void AddMilkPerSec(double milk)
    {
        _milkThisSecond += milk;
    }
}
