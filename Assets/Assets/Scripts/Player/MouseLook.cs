using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensibility = 100f;
    private float xRotation = 0f;

    public Transform playerBody;
    void Start()
    {
        // evitamos que el raton se salga de la ventana del juego 
        // oculta el mouse y solo dejar hacer focus en el juego, a no ser que le demos al esc
        // para bloquear el raton tenemos que hacer click en el juego
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensibility * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensibility * Time.deltaTime;
        
        xRotation -= mouseY;
        // nos aseguramos de que el player no puede mirar mas alla de 90º hacia abajo y 90º hacia arriba
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
        
    }
}
