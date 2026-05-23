using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class NightVisionScript : MonoBehaviour
{
    private Image zoomBar;
    private Image batteryChunks;
    private Camera cam;
    public float batteryPower = 1f;
    public float drainTime = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*Mouse ScrollWheel*/
        zoomBar = GameObject.Find("Zoom Bar").GetComponent<Image>();
        batteryChunks = GameObject.Find("BateryChunks").GetComponent<Image>();
        cam = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();
    }

    private void OnEnable()
    {
        InvokeRepeating("BatteryDrain", drainTime, drainTime);


        if (zoomBar != null)
        zoomBar.fillAmount = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if(cam.fieldOfView > 10)
            {
                cam.fieldOfView -= 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (cam.fieldOfView < 60)
            {
                cam.fieldOfView += 5;
                zoomBar.fillAmount = cam.fieldOfView / 100;
            }
        }

        batteryChunks.fillAmount = batteryPower;
    }

    private void BatteryDrain()
    {
        if(batteryPower > 0.0F)
        {
            batteryPower -= 0.25F;
        }
    }

    public void StopDrain()
    {
        CancelInvoke("BatteryDrain");
    }
}
