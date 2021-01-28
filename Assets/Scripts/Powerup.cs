using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Powerup: NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        NetworkServer.Destroy(gameObject);
    }
}
