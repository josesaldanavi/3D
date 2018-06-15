using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour {
    public float horizontalSpeed = 1;
    Vector3 movement;
    public Rigidbody rbd3d;
    public float angularSpeed;
    public float impulse;
    Quaternion rotation;

    public SwitchControl currentSwitch;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement = transform.position;
        rotation = rbd3d.rotation;
        float horizontalDirection = Input.GetAxis("Horizontal");
        float verticalDirection = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.J)){
            rotation *=Quaternion.Euler(Vector3.up*-angularSpeed*Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotation *= Quaternion.Euler(Vector3.up * angularSpeed * Time.fixedDeltaTime);
        }
        if(horizontalDirection != 0){
            movement += Vector3.right * horizontalSpeed * horizontalDirection * Time.fixedDeltaTime;
        }
        if (verticalDirection != 0)
        {
            movement += Vector3.forward * horizontalSpeed * verticalDirection * Time.fixedDeltaTime;
        }

        rbd3d.MovePosition(movement);
        rbd3d.MoveRotation(rotation);
	}
	private void FixedUpdate()
	{
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbd3d.AddForce(Vector3.up * impulse, ForceMode.Impulse);
        }
        if(currentSwitch!= null && Input.GetKeyDown(KeyCode.E)){
            currentSwitch.Active();
        }
	}
    //Se puede hacer con Raycast
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Switch")){
            currentSwitch = other.GetComponent<SwitchControl>();
        }
    }
	private void OnTriggerExit(Collider other)
	{
        if(other.CompareTag("Switch")){
            currentSwitch = null;
        }
	}
}
