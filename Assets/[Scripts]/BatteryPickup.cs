using UnityEngine;
using UnityEngine.UI;

public class BatteryPickup : MonoBehaviour
{
    public BatteryUI batteryItem;
    public float rechargePercent = 25f;

    public void UseBattery()
    {
        if (batteryItem == null)
            return;

        batteryItem.RechargeBattery(rechargePercent);

        gameObject.SetActive(false);

   
    }
}
