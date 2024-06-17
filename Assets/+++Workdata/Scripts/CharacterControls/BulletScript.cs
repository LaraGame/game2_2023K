using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); // for following the mouse
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force; // direction and force are made
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = quaternion.Euler(0,0);
    }

    
    // destroying enemys( moving kiling objects)
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Poison"))
        {
            //debug um sicherzugehen das es funkst
            Debug.Log("Headshot");
            Destroy(other.gameObject);
        }
    }
}
