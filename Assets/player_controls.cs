using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
     public float move_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     float horizontalInput = Input.GetAxisRaw("Horizontal");
     float verticalInput = Input.GetAxisRaw("Vertical"); 
     Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f).normalized * move_speed * Time.deltaTime;
     transform.Translate(movement);
    }
}
