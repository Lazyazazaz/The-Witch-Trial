using UnityEngine;


[RequireComponent(typeof(Animator))]

public class SkeletonAnimationController : MonoBehaviour
{
    [SerializeField] private EnemyBehaviorController _enemyBehaviorController;
    [SerializeField] private EnemyCharacter _enemyCharacter;

    private Animator _animator;

    private const string IS_RUNNING = "IsRunning";
    private const string CHASING_SPEED_MULTIPLIER = "ChasingSpeedMultiplier";
    private const string ATTACK = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _enemyBehaviorController.OnEnemyAttack += _enemyBehaviorController_OnEnemyAttack;
    }

    private void OnDestroy()
    {
        _enemyBehaviorController.OnEnemyAttack -= _enemyBehaviorController_OnEnemyAttack;
    }

    private void Update()
    {
        _animator.SetBool(IS_RUNNING, _enemyBehaviorController.IsRunning());
        _animator.SetFloat(CHASING_SPEED_MULTIPLIER, _enemyBehaviorController.GetRoamingAnimationSpeed());
    }

    public void TriggerAttackAnimationTurnOff()
    {
        _enemyCharacter.PolygonColliderTurnOff();
    }

    public void TriggerAttackAnimationTurnOn()
    {
        _enemyCharacter.PolygonColliderTurnOn();
    }

    private void _enemyBehaviorController_OnEnemyAttack(object sender, System.EventArgs e)
    {
        _animator.SetTrigger(ATTACK);
    }
}