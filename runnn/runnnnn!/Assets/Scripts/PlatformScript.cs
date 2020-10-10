using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    //Transform playerTransform;
    //private void Start()
    //{
    //    playerTransform = GetComponent<Transform>();
    //}
    void Update()
    {
        //transform.Translate(0, 0, -15f * Time.deltaTime);      //default code for movement
        //if(transform.localPosition.z<=-50f)
        //{
        //   transform.position = new Vector3(0, 0, 150);
        //}
        StartCoroutine(WaitForPlatform()    );
    }
    IEnumerator WaitForPlatform()
    {
        yield return new WaitForSeconds(4f);
        transform.Translate(0, 0, -15f * Time.deltaTime);
        if (transform.localPosition.z <= -50f)
        {
            transform.position = new Vector3(0, 0, 150);
        }
    }
}
