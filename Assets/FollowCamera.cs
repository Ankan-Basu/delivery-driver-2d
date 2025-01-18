using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject car = null; // drag drop car game obj from unity
    // Moves camera to the postion of the car
    void LateUpdate()
    {
        // postion of car + some height on the Z axis. otherwise it will at Z =0 directly where the car is
        transform.position = car.transform.position + new Vector3(0, 0, -10);
    }
}
