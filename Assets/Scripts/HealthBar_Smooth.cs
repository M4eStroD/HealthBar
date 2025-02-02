using System.Collections;
using UnityEngine;

public class HealthBar_Smooth : HealthBar
{
    private float _stepHealthChange = 0.5f;
    private float _currentStep = 0;

    private bool _isActive = false;

    protected override void ChangeHealthBar()
    {
        _currentStep += _stepHealthChange;

        if (_isActive == false)
            StartCoroutine(HealthBar());
    }

    private IEnumerator HealthBar()
    {
        float reductionFactor = 100;
        _isActive = true;

        while (Bar.value != GetPercentBar() / reductionFactor)
        {
            Bar.value = Mathf.MoveTowards(Bar.value, GetPercentBar() / reductionFactor, _currentStep * Time.deltaTime);
            yield return null;
        }

        _currentStep = 0;
        _isActive = false;
    }
}
