using UnityEngine;
using UnityEngine.UI;

public class FlishLightScript : MonoBehaviour
{
    private Image batteryChunks;
    public float batteryPower = 1f;
    public float drainTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        batteryChunks = GameObject.Find("FL BatteryChunks").GetComponent<Image>();
        InvokeRepeating("FLBatteryDrain", drainTime, drainTime);
    }

    // Update is called once per frame
    void Update()
    {
        batteryChunks.fillAmount = batteryPower;
    }

    private void FLBatteryDrain()
    {
        if (batteryPower > 0.0F)
        {
            batteryPower -= 0.25F;
        }
    }

    public void StopDrain()
    {
        CancelInvoke("FLBatteryDrain");
    }
}
