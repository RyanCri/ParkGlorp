using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectable : MonoBehaviour
{

    private int Fruit = 0;

    private void OnTriggerEnter(Collider other)
    {
        print("hello");
        Debug.Log("yo", other);
        if (other.transform.tag == "Fruit")
            {
            Fruit++;
            Debug.Log(Fruit);
            Destroy(other.gameObject);
            }
    }
}
