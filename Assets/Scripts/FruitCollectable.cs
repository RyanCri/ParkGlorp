using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectable : MonoBehaviour
{

    private int Fruit = 0;
    
    public void onTriggerEnter(Collider other)
    {
        Debug.Log("yo", other);
        /*if (other.transform.tag == "Fruit")
            {
            Fruit++;
            Debug.Log(Fruit);
            Destroy(other.gameObject);
            }*/
    }
}
