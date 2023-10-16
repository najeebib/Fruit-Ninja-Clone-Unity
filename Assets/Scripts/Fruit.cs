using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    //create new fruit
    public void CreateSlicedFruit(int score)
    {
        // init the fruit
        GameObject inst = (GameObject)Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        // add force for the sliced fruit, so that it flys when sliced
        Rigidbody[] rbsOnSliced =  inst.GetComponentsInChildren<Rigidbody>();
        FindAnyObjectByType<GameManager>().SliceSound();
        foreach (Rigidbody rigidbody in rbsOnSliced) 
        {
            rigidbody.transform.rotation = Random.rotation;
            rigidbody.AddExplosionForce(Random.Range(150, 350), transform.position, 5);
        }
        FindAnyObjectByType<GameManager>().IncreseScore(score);
        Destroy(inst, 5);
        Destroy(gameObject);
    }
    // when a collision with blade is detected slice the fruit
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Blade b = collision.GetComponent<Blade>();
        // give each fruit a different score
        if(!b) return;
        if(GetComponent<Fruit>().ToString().Contains("Orange"))
        {
            CreateSlicedFruit(1);
        }
        else if(GetComponent<Fruit>().ToString().Contains("Banana"))
        {
            CreateSlicedFruit(2);
        }
        else
            CreateSlicedFruit(3);
    }
}
