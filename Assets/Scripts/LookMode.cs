using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LookMode : MonoBehaviour
{
    private PostProcessVolume vol;
    public PostProcessProfile standerd;
    public PostProcessProfile nightVision;
    public PostProcessProfile inventory;
    public GameObject nightVisionOverlay;
    public GameObject flishLightOverlay;
    public GameObject inventoryMenu;
    private Light flishLight;
    private bool nightVisionIsOn = false;
    private bool flishLightIsOn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vol = GetComponent<PostProcessVolume>();
        flishLight = GameObject.Find("FlishLight").GetComponent<Light>();
        flishLight.enabled = false;
        nightVisionOverlay.SetActive(false);
        flishLightOverlay.SetActive(false);
        inventoryMenu.SetActive(false); 
        vol.profile = standerd; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (!nightVisionIsOn)
            {
                vol.profile = nightVision;
                nightVisionOverlay.SetActive(true);
                nightVisionIsOn = true;
                NightVisionOff();
            }
            else if (nightVisionIsOn)
            {
                vol.profile = standerd;
                nightVisionOverlay.SetActive(false);
                nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                nightVisionIsOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!flishLightIsOn)
            {
                flishLightOverlay.SetActive(true);
                flishLightIsOn = true;
                flishLight.enabled = true;
                FlishLightOff();
            }
            else if (flishLightIsOn)
            {
                flishLight.enabled = false;
                flishLightOverlay.SetActive(false);
                flishLightOverlay.GetComponent<FlishLightScript>().StopDrain();
                flishLightIsOn = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if(SaveScript.inventoryOpen == false)
            {
                vol.profile = inventory;
                inventoryMenu.SetActive(true);

                if (flishLightIsOn)
                {
                    flishLight.enabled = false;
                    flishLightOverlay.SetActive(false);
                    flishLightOverlay.GetComponent<FlishLightScript>().StopDrain();
                    flishLightIsOn = false;
                }

                if (nightVisionIsOn)
                {
/*                    vol.profile = standerd;*/
                    nightVisionOverlay.SetActive(false);
                    nightVisionOverlay.GetComponent<NightVisionScript>().StopDrain();
                    this.gameObject.GetComponent<Camera>().fieldOfView = 60;
                    nightVisionIsOn = false;
                }
            }
            else if (SaveScript.inventoryOpen == true)
            {
                vol.profile = standerd;
                inventoryMenu.SetActive(false);
            }
        }

        if (nightVisionIsOn)
        {
            NightVisionOff();
        }

        if (flishLightIsOn)
        {
            FlishLightOff();
        }
    }

    private void NightVisionOff()
    {
        if (nightVisionOverlay.GetComponent<NightVisionScript>().batteryPower <= 0)
        {
            vol.profile = standerd;
            nightVisionOverlay.SetActive(false);
            this.gameObject.GetComponent<Camera>().fieldOfView = 60;
            nightVisionIsOn = false;
        }
    }

    private void FlishLightOff()
    {
        if (flishLightOverlay.GetComponent<FlishLightScript>().batteryPower <= 0)
        {
            flishLight.enabled = false;
            flishLightOverlay.SetActive(false);
            flishLightOverlay.GetComponent<FlishLightScript>().StopDrain();
            flishLightIsOn = false;
        }
    }
}
