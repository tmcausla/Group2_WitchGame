using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    public BossStateMachine StateMachine {  get; private set; }

    public Transform LightningOne;
    public Transform LightningTwo;
    public Transform LightningThree;
    public Transform LightningFour;
    public Transform LightningFive;
    public GameObject LightningStrike;
    public Transform player;
    public Transform ChargePoint;
    public Transform EndCharge;
    public Transform MiddlePoint;
    public bool isFlipped;
    public float counter;
    public StartFight StartFight { get; private set; }
    public NormalChase NormalChase { get; private set; }
    public NormalCharge NormalCharge { get; private set; }
    public RestTime RestTime { get; private set; }
    public BecomeEnraged BecomeEnraged { get; private set; }
    public EnragedCharge EnragedCharge { get; private set; }
    public EnragedChase EnragedChase { get; private set; }
    public EnragedRest EnragedRest { get; private set; }
    public LightningRound LightningRound { get; private set; }
    public BossAttack BossAttack { get; private set; }
    public EnragedAttack EnragedAttack { get; private set; }

    [SerializeField]
    private BossData bossData;

    public Animator Anim { get; private set; }
    public Rigidbody2D rb {  get; private set; }
    public BoxCollider2D Collider2D { get; private set; }
    public SpriteRenderer sprite { get; private set; }


    public Vector2 CurrentVelocity { get; private set; }

    private Vector2 workspace;


    private void Awake()
    {
        StateMachine = new BossStateMachine();

        StartFight = new StartFight(this, StateMachine, bossData, "start");
        NormalChase = new NormalChase(this, StateMachine, bossData, "chase");
        NormalCharge = new NormalCharge(this, StateMachine, bossData, "charge");
        RestTime = new RestTime(this, StateMachine, bossData, "rest");
        BecomeEnraged = new BecomeEnraged(this, StateMachine, bossData, "angry");
        EnragedCharge = new EnragedCharge(this, StateMachine, bossData, "angrycharge");
        EnragedChase = new EnragedChase(this, StateMachine, bossData, "angrychase");
        EnragedRest = new EnragedRest(this, StateMachine, bossData, "angryrest");
        LightningRound = new LightningRound(this, StateMachine, bossData, "lightning");
        BossAttack = new BossAttack(this, StateMachine, bossData, "attack");
        EnragedAttack = new EnragedAttack(this, StateMachine, bossData, "angryattack");

    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();

        StateMachine.Initialize(StartFight);
    }

    private void Update()
    {
        CurrentVelocity = rb.velocity;
        StateMachine.CurrentState.LogicUpdate();

    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void SetVelocityX(float velocity)
    {
        workspace.Set(velocity * (transform.position.x - player.position.x), CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetChargeVelocity(float velocity)
    {
        workspace.Set(velocity, CurrentVelocity.y);
        rb.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void StartCharge()
    {
        transform.position = ChargePoint.position;
    }

    public void ReturnToMiddle()
    {
        transform.position = MiddlePoint.position;
    }

    public void CheckIfShouldFlip()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void ChargeDirection()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if (isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public bool CheckRange()
    {
        return Vector2.Distance(transform.position, player.transform.position) < bossData.range;
        
    }
    public bool CheckCharge()
    {
        return Vector2.Distance(transform.position, EndCharge.position) < 1f;
    }

    public void LightningAttack()
    {
        Instantiate(LightningStrike, LightningOne.position, Quaternion.identity);
        Destroy(LightningStrike, 1);
        Instantiate(LightningStrike, LightningTwo.position, Quaternion.identity);
        Destroy(LightningStrike, 1);
        Instantiate(LightningStrike, LightningThree.position, Quaternion.identity);
        Destroy(LightningStrike, 1);
        Instantiate(LightningStrike, LightningFour.position, Quaternion.identity);
        Destroy(LightningStrike, 1);
        Instantiate(LightningStrike, LightningFive.position, Quaternion.identity);
        Destroy(LightningStrike, 1);
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
}
