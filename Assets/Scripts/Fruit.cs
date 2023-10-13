using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            CreateSlicedFruit();
        }
    }

    public void CreateSlicedFruit()
    {
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);

        Rigidbody[] rbsOnSliced =  inst.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rbsOnSliced) 
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(150, 350), transform.position, 5);
        }

        Destroy(gameObject);
    }
}
