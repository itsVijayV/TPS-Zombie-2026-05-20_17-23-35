using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotateSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.Rotate(50, 50, 50);
    }

    // Update is called once per frame
    void Update()
    {
         //transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}
