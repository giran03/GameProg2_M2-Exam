using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] List<Transform> playerOrientation;
    [SerializeField] List<Transform> playerParent;
    [SerializeField] List<Transform> playerModel;
    Transform orientation;
    Transform player;
    Transform playerObj;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        orientation = playerOrientation.First(r => r.gameObject.activeInHierarchy);
        player = playerParent.First(r => r.gameObject.activeInHierarchy);
        playerObj = playerModel.First(r => r.gameObject.activeInHierarchy);

        // rotate orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        // rotate player object
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    }
}
