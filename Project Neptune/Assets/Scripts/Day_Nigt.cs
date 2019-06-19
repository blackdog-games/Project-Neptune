using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_Nigt : MonoBehaviour
{
    [Header("Time")]
    [Tooltip("Day Length in Minutes")]
    [SerializeField]
    private float _targetDayLength = .5f; // In minutes
    public float targetDayLength
    {
        get
        {
            return _targetDayLength;
        }
    }
    [SerializeField]
    [Range(0f, 1f)]
    private float _timeOfDay;
    public float timeOfDay
    {
        get
        {
            return _timeOfDay;
        }
    }
    [SerializeField]
    private int _dayNumber = 0;
    public int dayNumber
    {
        get
        {
            return _dayNumber;
        }
    }
    [SerializeField]
    private int _yearNumber = 0;
    public int yearNumber
    {
        get
        {
            return _yearNumber;
        }
    }
    private float _timeScale = 100f;
    [SerializeField]
    private int _yearLength = 100;
    public float yearLength
    {
        get
        {
            return _yearLength;
        }
    }
    public bool pause = false;

    [Header("Sun Light")]
    [SerializeField]
    private Transform dailyRotation;
    [SerializeField]
    private Light Sun;
    private float intensity;
    [SerializeField]
    private float sunBaseIntensity = 1f;
    [SerializeField]
    private float sunVariation = 1.5f;
    [SerializeField]
    private Gradient sunColour;



    private void Update()
    {
        if (!pause)
        {
            UpdateTimeScale();
            UpdateTime();
        }
        AdjustSunRotation();
        SunIntensity();
        AdjustSunColour();
    }


    private void UpdateTimeScale()
    {
        _timeScale = 24 / (_targetDayLength / 60);
    }
    private void UpdateTime()
    {
        _timeOfDay += Time.deltaTime * _timeScale / 86400;
        if (_timeOfDay > 1)
        {
            _dayNumber++;
            _timeOfDay--;
        }
        if (_dayNumber > _yearLength)
        {
            _yearNumber++;
            _dayNumber = 0;
        }
    }
    private void AdjustSunRotation()
    {
        float sunAngle = timeOfDay * 360f;
        dailyRotation.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, sunAngle));
    }
    private void SunIntensity()
    {
        intensity = Vector3.Dot(Sun.transform.forward, Vector3.down);
        intensity = Mathf.Clamp01(intensity);

        Sun.intensity = intensity * sunVariation + sunBaseIntensity;
    }
    private void AdjustSunColour()
    {
        Sun.color = sunColour.Evaluate(intensity);
    }
}
