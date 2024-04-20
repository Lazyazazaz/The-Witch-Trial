using UnityEngine;

public class CharacterWeaponController : MonoBehaviour
{
    public static CharacterWeaponController Instance { get; private set; }

    [SerializeField] private Sword sword;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        FollowMousePosition();
    }

    private void FollowMousePosition()
    {
        Vector3 mousePos = CharacterControls.Instance.GetMousePosition();
        Vector3 playerPosition = Character.Instance.GetCharacterScreenPosition();

        if (mousePos.x < playerPosition.x)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public Sword GetActiveWeapon()
    {
        return sword;
    }
}
