using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    private Camera mainCam;
    private bool isFacingRight = true;
    private float inputDirection; //damit man es überall nutzen kann

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire; // so the player can shoot
    private float timer; // timer + time in between firing 
    public float timeBetweenFiring;

    private Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        // to follow the mouse position
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;
        // freezing the Z rotation
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        // can fire after a selfset time
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                // restart so you can fire again
                canFire = true;
                timer = 0;
            }
        }

        // if mouse is pressed than it will fire
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        
        
    }
    
   
}

