using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum JetpackState
{
    JETPACK_ON, JETPACK_OFF
}
public class Jetpack : MonoBehaviour
{
    private JetpackState jetpackState;
    public JetpackState JetpackState { private get => jetpackState; set => jetpackState = value; }

    [SerializeField] private Slider jetpackSlider;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private float rechargeRate;
    private float drainRate = 2f;
    [SerializeField] private float fuelAmount;
    private float maxFuelAmount;
    [SerializeField] private float boostStrength;
    public float BoostStrength { get => boostStrength; private set => boostStrength = value; }

    private void Awake()
    {
        SetMaxFuel();
        JetpackState = JetpackState.JETPACK_OFF;
    }

    private void Update()
    {
        FuelLoad();
        FuelDrain();
        UpdateJetpackUI();
    }

    private void SetMaxFuel()
    {
        maxFuelAmount = fuelAmount;
    }

    private void FuelLoad()
    {
        if (playerController.SphereState == SphereState.IS_ON_GROUND && fuelAmount < maxFuelAmount)
            fuelAmount += rechargeRate * Time.deltaTime;
    }

    private void FuelDrain()
    {
        if (JetpackState == JetpackState.JETPACK_ON && fuelAmount > 0f)
            fuelAmount -= drainRate * Time.deltaTime;
    }

    private void UpdateJetpackUI()
    {
        float fuelPercentage = fuelAmount / maxFuelAmount;
        if (fuelPercentage >= 0f && fuelPercentage <= 1f)
            jetpackSlider.value = fuelPercentage;
    }
}
