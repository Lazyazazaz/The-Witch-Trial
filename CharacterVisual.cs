using UnityEngine;

public class CharacterVisual : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private const string IS_RUNNING = "IsRunning";

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetBool(IS_RUNNING, Character.Instance.IsRunning());
        AdjustCharacterFacingDirection();
    }

    private void AdjustCharacterFacingDirection()
    {
        Vector3 mousePosition = CharacterControls.Instance.GetMousePosition();
        Vector3 characterPosition = Character.Instance.GetCharacterScreenPosition();

        if (mousePosition.x < characterPosition.x)
            spriteRenderer.flipX = true;
        else
            spriteRenderer.flipX = false;
    }
}