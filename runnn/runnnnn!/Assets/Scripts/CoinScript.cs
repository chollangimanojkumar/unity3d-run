using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1f);
        transform.Translate(0, 0, -15f * Time.deltaTime);
        if (transform.localPosition.z <= -50)
        {
            Destroy(this.gameObject);
        } 
        
    }
}
