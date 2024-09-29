using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField, Range(0f, 1f)] private float verticalMultiplier;

    private PlayerControlScheme controlScheme;

    private Rigidbody2D rb2d;
    private Vector2 moveDir;

    void Awake()
    {
        controlScheme = new PlayerControlScheme();

        rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        controlScheme.Player.Movement.Enable();
    }

    private void OnDisable()
    {
        controlScheme.Player.Movement.Disable();
    }

    void Update()
    {
        moveDir = controlScheme.Player.Movement.ReadValue<Vector2>().normalized;
        moveDir.y *= verticalMultiplier;

        rb2d.velocity = moveDir * speed;
    }
}
