using UnityEngine;

public class Move : MonoBehaviour
{

    public float moveSpeed = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*transform.Translate(50, 50, 50);*/
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        transform.position = transform.position + Vector3.up * moveSpeed * Time.deltaTime; 
    }
}
