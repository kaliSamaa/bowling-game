using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class Launch : MonoBehaviour
{

    public Rigidbody rb;
    Rigidbody pinRB;
    float startTime;
    private Vector3 launchForce;
    private bool isLaunching;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        launchForce = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyDown(KeyCode.Space))
        {
          startTime  =Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            float durationTime = Time.time - startTime;
            launchForce = Vector3.forward * durationTime * 1000; 
            rb.isKinematic = false;
            rb.AddForce(launchForce);

        }
        if (Input.GetKeyDown(KeyCode.R) )
        {
            Restart();
        }
        
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) 
            { 
                startTime = Time.time; 
            }

            if (Input.GetKey(KeyCode.LeftArrow)) { 
                float pressDuration = Time.time - startTime; 
                launchForce += Vector3.left * pressDuration * 100;
                //transform.Rotate(Vector3.up / 5f);
                rb.AddTorque(new Vector3(0, 0, 1) * 300f * Time.deltaTime, ForceMode.Force); // Rotate left


            } 
            else if (Input.GetKey(KeyCode.RightArrow)) { 
                float pressDuration = Time.time - startTime;
                launchForce += Vector3.right * pressDuration * 100;
                // transform.Rotate(-Vector3.up / 5f);
                rb.AddTorque(new Vector3(0, 0, -1) * 300f * Time.deltaTime, ForceMode.Force); // Rotate left


            }
        }
    
   public void  Restart()
    {
        rb.isKinematic = true;
        rb.transform.position = new Vector3(0, 0.5f, 0);
        GameObject[] pins = GameObject.FindGameObjectsWithTag("Pin");
        foreach (GameObject pin in pins)
        {
            Pin pinScript = pin.GetComponent<Pin>();
           
            pin.transform.position = pinScript.initialPosition; 
            pin.transform.rotation = pinScript.initialRotation;
            pin.GetComponent<Rigidbody>().linearVelocity = Vector3.zero; 
            pin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;



        }

    }
}
