using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int myID;
    public float health = 100.0f;
    public float movementSpeed = 20f;
    enum CastState { Charging,Charged, Recharging ,Neutral};
    CastState myState = CastState.Neutral;
    public Rigidbody rb;
    Transform myTrans;
    [SerializeField] Transform spellSpawn;
    [SerializeField] GameObject charging;
    [SerializeField] GameObject charged;
    public float delayTime = .1f; //maybe remove this?
    public float chargeTime = 1.5f;
    public float StartCharge = 0.0f;
    public float StartDelay = 0.0f;
    static float maxSpells = 5f;
    private Queue<Spell> mySpells = new Queue<Spell>();
    public GameController myDad;
    bool stunned = false;
    [SerializeField]NextSpellScript myGUI;
    private bool hasDied = false;
	// Use this for initialization
	void Start () {
        myTrans = transform;
        //myGUI = GetComponentInChildren<NextSpellScript>();
    }

    public void AddSpell(Spell newSpell)
    {
        if (mySpells.Count > maxSpells) { mySpells.Dequeue(); }
        mySpells.Enqueue(newSpell);
        SpellSpriteHandler();
    }

    public void MoveSelf(Vector3 dir) {
        if (stunned) { return; }
        float mySpeed = myState == CastState.Charging || myState == CastState.Charged ? movementSpeed * 0.25f : movementSpeed;
        if(rb != null) rb.velocity = dir*mySpeed;

    }

    public void RotateSelf(Vector3 aimDirection) {
        transform.LookAt(transform.position + aimDirection);
    }

    private void FixedUpdate()
    {
        if (myState == CastState.Charging)
        {
            //check the time
            if (Time.time - StartCharge >= mySpells.Peek().ChargeTime())
            {
                myState = CastState.Charged;
            }

        }
        else if (myState == CastState.Recharging)
        {

            //check the time
            if (Time.time - StartDelay >= delayTime)
            {
                myState = CastState.Neutral;
            }

        }

    }

    void UnStun()
    {
        stunned = false;
    }

    private void Update()
    {  
        //emitter update -> this is bad and shouldnt be tolerated but its like 1AM and we all make mistakes
        if (myState == CastState.Charging)
        {
            charging.SetActive(true);
            charged.SetActive(false);
        }
        else if (myState == CastState.Charged)
        {
            charging.SetActive(false);
            charged.SetActive(true);
        }
        else {
            charging.SetActive(false);
            charged.SetActive(false);
        }

    }


    void SpellSpriteHandler()
    {
        switch (mySpells.Peek().myName())

        {
            case "Fireball": myGUI.ChangeSpell("fireball"); break;
            case "MagicMissle": myGUI.ChangeSpell("missle"); break;
            case "FogetMeNot": myGUI.ChangeSpell("forget"); break;
            case "Heal": myGUI.ChangeSpell("heal"); break;
            case "Push": myGUI.ChangeSpell("yeet"); break;
            case "Teleport": myGUI.ChangeSpell("teleport"); break;

            default:break;

        }

    }

    void ChargeSpell()
    {

        if (myState == CastState.Neutral)
        {
            StartCharge = Time.time;
            myState = CastState.Charging;
        }
    }

    public void ButtonDown() {
        ChargeSpell();
    }

    public void ButtonUp() {
        if (myState == CastState.Charged)
        {
            mySpells.Dequeue().Activate(spellSpawn.position, transform.forward ,myTrans);
            SpellSpriteHandler();
            StartCharge = 0.0f;
            myState = CastState.Recharging;
            StartDelay = Time.time;
            mySpells.Enqueue(myDad.GetNewSpell());//get a new spell for the list!
        }
        else {
            myState = CastState.Neutral;
        }
    }

    public void Damage(float incomingDamage) {
        health -= incomingDamage;
        if (health <= 0.0f) {
            if (!hasDied) Die();
        }
    }

    public void Knockback(Vector3 dir, float velocity, float stun) {
        stunned = true;
        rb.AddForce(dir * velocity, ForceMode.Impulse);
        Invoke("UnStun", stun);
    }

    private void Die() {
        stunned = false;
        myDad.WizardDeath();
        Destroy(gameObject);
    }

}
