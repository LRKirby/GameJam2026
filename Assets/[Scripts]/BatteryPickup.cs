using UnityEngine;
using UnityEngine.EventSystems;

public class BatteryPickup : MonoBehaviour
{
    public BatteryUI batteryUI;
    public float rechargePercent;

   
    public void UseBattery()
    {
        if (batteryUI == null)
            return;

        if (batteryUI.IsFull())
        {
            Debug.Log("Battery already full!");
            return;
        }


        batteryUI.RechargeBattery(rechargePercent);


        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        Destroy(clickedButton);
    }
}
