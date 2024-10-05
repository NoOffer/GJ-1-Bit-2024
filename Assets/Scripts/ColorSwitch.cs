using UnityEngine;
using UnityEngine.InputSystem;

public class ColorSwitch : MonoBehaviour
{
    [SerializeField] private Material colorSwitchMat;
    [SerializeField] private Color bgColor;
    [SerializeField] private Color fgColor;

    private PlayerControlScheme controlScheme;

    void Awake()
    {
        controlScheme = new PlayerControlScheme();
        controlScheme.Player.ColorSwitch.performed += SwitchColor;
    }

    private void OnEnable()
    {
        controlScheme.Player.ColorSwitch.Enable();
    }

    private void OnDisable()
    {
        controlScheme.Player.ColorSwitch.Disable();
    }

    private void SwitchColor(InputAction.CallbackContext ctx)
    {
        Color temp = bgColor;
        bgColor = fgColor;
        fgColor = temp;

        colorSwitchMat.SetColor("_BgColor", bgColor);
        colorSwitchMat.SetColor("_FgColor", fgColor);

        Camera.main.backgroundColor = bgColor;
    }
}
