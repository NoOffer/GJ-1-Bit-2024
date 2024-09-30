using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 rangeMultiplier;

    private Vector3 originalOffset;

    void Start()
    {

        originalOffset = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        Vector3 cursorOffset = Mouse.current.position.ReadValue();
        cursorOffset.x = (cursorOffset.x / Screen.width * 2f - 1f) * rangeMultiplier.x;
        cursorOffset.y = (cursorOffset.y / Screen.height * 2f - 1f) * rangeMultiplier.y;

        transform.position = target.transform.position + originalOffset + cursorOffset;
    }
}
