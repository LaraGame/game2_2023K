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
    public bool canFire;
    private float timer;
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
        
        transform.rotation = Quaternion.Euler(0,0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        
        
        // wenn das in der klammer steht m,ache was in den geschiffenen klammern steht
        // wenn größer als nbull dann Face right wenn nicht stimmt dann lass es
        // && und   || oder
        if (inputDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (inputDirection < 0 && isFacingRight)
        {
            Flip();
        }
       
    }
    void Flip()
    { // transform auffinden dann localscale ansehen
        Vector3 currentScale = transform.localScale;
        currentScale.x = currentScale.x * -1;
        transform.localScale = currentScale;
        // verändern dann alten currentScale in minus und setze ihn neu an
        isFacingRight = !isFacingRight;
        // damitz auch die richtig facing stimmt nochmal reinschreiben
    }
    
    
}

