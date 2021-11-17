using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;
    public Vector3 offset;
    public Character character;

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView > 10)
            {
                Camera.main.fieldOfView -= 5f;
            }
            else if (Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView < 100)
            {
                Camera.main.fieldOfView += 5f;
            }
        }
        //transform.position = Vector3.Lerp(transform.position, character.transform.position + offset, lerpSpeed * Time.deltaTime);
    }

    private void LateUpdate()
    {
        transform.position = character.transform.position + offset;
        transform.rotation = character.transform.rotation;
    }
}