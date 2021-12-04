using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody TargetRb;

    private float MinSpeed = 12;
    private float MaxSpeed = 16;

    private float MaxTorque = 10;

    private float xRange = 4;
    private float SpawnPosY = -6;
    // Start is called before the first frame update
    void Start()
    {
        TargetRb = GetComponent<Rigidbody>();

        TargetRb.AddForce(Randomforce(), ForceMode.Impulse);
        TargetRb.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse);

        transform.position = RandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    Vector3 Randomforce()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }
    float randomTorque()
    {
        return (Random.Range(-MaxTorque, MaxTorque));
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), SpawnPosY);
    }
}
