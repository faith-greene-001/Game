using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class playermove : MonoBehaviour {
    public float speed = 30.0f;
    public float gravity = -9.8f;
    public bool alive;
	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();
        alive = true;
    }

    private CharacterController _charController;

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);
            movement.y = gravity;
            _charController.Move(movement);
        }

    }

    public void SetAlivep(bool alivep)
    {
        alive = alivep;
    }
}
