using UnityEngine;

public class Pin : MonoBehaviour
{
    public Vector3 initialPosition; 
    public Quaternion initialRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
