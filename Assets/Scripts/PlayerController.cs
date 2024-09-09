using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0f, 10f)]
    public float speed = 1f;

    private CharacterController characterController;
    private float inputZ, inputX;

    // Called when the script becomes active
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        //Debug.Log("Character controller is attached to " + characterController.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        WalkKeyboard();
    }

    /// <summary>
    /// Collects and returns keyboard inputs
    /// </summary>
    /// <returns>Tuple object (z, x) with values being either 1 or 0</returns>
    private (float z, float x) GetKeyboardInput()
    {
        return (Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
    }

    /// <summary>
    /// Makes character walk along x and/or z axis based on keyboard inputs
    /// </summary>
    private void WalkKeyboard()
    {
        (inputZ, inputX) = GetKeyboardInput();

        characterController.SimpleMove((inputX * transform.right + inputZ * transform.forward).normalized * speed);
    }
}
