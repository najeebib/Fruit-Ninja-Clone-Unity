using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;
    private Vector3 lastMousePos;
    private Vector3 mouseVelo;

    private Collider2D col;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // make the blade active only when the mouse is moving
        col.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
        //set the blade to the mouse
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    private bool IsMouseMoving()
    {
        // check if the mouse is moving
        Vector3 curMousePos = Input.mousePosition;
        float traveled = (lastMousePos - curMousePos).magnitude;
        lastMousePos = curMousePos;
        if(traveled > minVelo) 
            return true;
        else
            return false;
    }
}
