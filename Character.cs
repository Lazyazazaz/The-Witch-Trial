using UnityEngine;


[SelectionBase]

public class Character : MonoBehaviour
{
    public static Character Instance { get; private set; }

    [SerializeField] private float movingSpeed = 10f;
    Vector2 inputVector;

    private Rigidbody2D _rigidBody;

    private float _minMovingSpeed = 0.1f;
    private bool _isRunning = false;

    private void Awake()
    {
        Instance = this;
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CharacterControls.Instance.OnCharacterAttack += HelperFunctions_OnCharacterAttack;
    }

    private void HelperFunctions_OnCharacterAttack(object sender, System.EventArgs e)
    {
        CharacterWeaponController.Instance.GetActiveWeapon().PerformAttack();
    }

    private void Update()
    {
        inputVector = CharacterControls.Instance.GetMovementVector();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        _rigidBody.MovePosition(_rigidBody.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > _minMovingSpeed || Mathf.Abs(inputVector.y) > _minMovingSpeed)
            _isRunning = true;
        else
            _isRunning = false;
    }

    public bool IsRunning()
    {
        return _isRunning;
    }

    public Vector3 GetCharacterScreenPosition()
    { 
        return Camera.main.WorldToScreenPoint(transform.position);
    }
}