using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    [SerializeField] CharacterController controller;
    [SerializeField] Camera camera;
    [SerializeField] GameObject player;
    [SerializeField] float sensetive = 0.5f;

    float mouse_x;
    float mouse_y;

    // Start is called before the first frame update

    private void Update()
    {
        MoveController();

        CameraController();
    }

    private void CameraController()
    {
        mouse_x += Input.GetAxis("Mouse X") * sensetive;
        mouse_y += Input.GetAxis("Mouse Y") * sensetive;

        camera.transform.rotation = Quaternion.Euler(-mouse_y, mouse_x, 0f);
        player.transform.localRotation = Quaternion.Euler(0,mouse_x,0);

    }

    private void MoveController()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
            controller.Move(Vector3.up * jumpForce * Time.deltaTime);
        }
        else
        { controller.Move(Vector3.down * 9 * Time.deltaTime); }
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
        {

            if (Input.GetAxis("Vertical") > 0)
            {
                controller.Move(Vector3.forward * speed * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                controller.Move(Vector3.back * speed * Time.deltaTime);
            }

            if (Input.GetAxis("Horizontal") > 0)
            {
                controller.Move(Vector3.right * speed * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                controller.Move(Vector3.left * speed * Time.deltaTime);
            }
        }
    }
}
