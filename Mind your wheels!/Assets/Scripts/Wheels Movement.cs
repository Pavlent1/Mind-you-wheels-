
using UnityEngine;

public class WheelsMovement : MonoBehaviour
{
    [SerializeField] Rigidbody L_Wheel;
    [SerializeField] Rigidbody R_Wheel;

    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float torqueCorrectionSpeed = 5f;

    private void Update()
    {
        float mouseSpeed = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.A))
        {
            L_Wheel.AddTorque(L_Wheel.transform.up * rotationSpeed * mouseSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            R_Wheel.AddTorque(R_Wheel.transform.up * rotationSpeed * mouseSpeed);
        }

        float currentZRotation = transform.localEulerAngles.z;
        if (currentZRotation > 180) currentZRotation -= 360; // Normalize to range -180 to 180

        if (Mathf.Abs(currentZRotation) > 0.1f)
        {
            float correctionTorque = Mathf.Lerp(currentZRotation, 0, torqueCorrectionSpeed * Time.deltaTime);
            transform.Rotate(0, 0, -correctionTorque);
        }
    }
}
