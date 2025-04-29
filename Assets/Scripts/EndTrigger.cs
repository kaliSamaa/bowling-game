using UnityEngine;

public class EndTrigger : MonoBehaviour

{
    public Launch reset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reset = FindAnyObjectByType<Launch>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            reset.Restart();
        }
    }
}
