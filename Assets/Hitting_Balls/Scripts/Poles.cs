using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poles : MonoBehaviour
{
    void OnCollisionEnter(Collision objHit)
    {
        if((objHit.gameObject.tag.Equals("ball")))
        {
            Debug.Log("hit");
            Destroy(objHit.gameObject);
        }
    }
}
