using UnityEngine;

public class LighterScript : MonoBehaviour
{
    public GameObject lightObj;

    private void OnEnable()
    {
        lightObj.SetActive(true);
    }

    private void OnDisable()
    {
        lightObj.SetActive(false);
    }
}
