using UnityEngine;

public class MainCameraRotation : MonoBehaviour
{
    public GameObject pivot;

    void Update()
    {
        transform.LookAt(pivot.transform);
        transform.Translate(Vector3.right * Time.deltaTime);

    }
}
