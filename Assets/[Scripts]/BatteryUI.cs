using UnityEngine;
using UnityEngine.UI;

public class BatteryUI : MonoBehaviour
{
    public GameObject FlashLight;
    public bool flashlightDead;

    public float batteryLife = 5f;

    public Image battery_100;
    public Image battery_75;
    public Image battery_50;
    public Image battery_25;
    public Image battery_0;


    private float currentBatteryLife;

    private void Start()
    {
        currentBatteryLife = batteryLife;
        UpdateBatteryUI();
    }


    private void Update()
    {
        if (FlashLight.activeInHierarchy)
        {
            currentBatteryLife -= Time.deltaTime;
        }
        
        if (currentBatteryLife <= 0)
        {
            currentBatteryLife = 0;
        }
        UpdateBatteryUI();
    }

    private void UpdateBatteryUI()
    {
        float batteryPercentage = (currentBatteryLife / batteryLife) * 100f;
        battery_100.enabled = batteryPercentage > 75f;
        battery_75.enabled = batteryPercentage <= 75f && batteryPercentage > 50f;
        battery_50.enabled = batteryPercentage <= 50f && batteryPercentage > 25f;
        battery_25.enabled = batteryPercentage <= 25f && batteryPercentage > 0f;
        battery_0.enabled = batteryPercentage <= 0f;


        if (batteryPercentage <= 0f)
        {
            flashlightDead = true;
        }



    }
    public void RechargeBattery(float percent)
    {
        float amount = batteryLife * (percent / 100f);
        currentBatteryLife += amount;

        if (currentBatteryLife > batteryLife)
            currentBatteryLife = batteryLife;

        flashlightDead = false;
        UpdateBatteryUI();
    }

    public bool IsFull()
    {
        return currentBatteryLife >= batteryLife;
    }

}



