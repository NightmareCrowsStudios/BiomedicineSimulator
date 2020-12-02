using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    /////////////////////// USAR PREFAB DO PLAYER NO CORPODOPLAYER //////////////////////////
    public float sensibilidade = 65f;
    public Transform corpoDoPlayer;
    float xRotaçao = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensibilidade * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidade * Time.deltaTime;

        xRotaçao -= mouseY;
        xRotaçao = Mathf.Clamp(xRotaçao, -65f, 65f);

        transform.localRotation = Quaternion.Euler(xRotaçao, 0f, 0f);
        corpoDoPlayer.Rotate(Vector3.up * mouseX);
    }
}
