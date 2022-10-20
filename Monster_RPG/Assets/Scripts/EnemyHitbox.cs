using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
    //Damage
    public int damage;
    public float pushForce;
    [SerializeField] private AudioSource monsterAttackSoundEffect;


    //Sound cooldown
    protected float coolTime = 3.0f;
    protected float lastCool;
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "Player")
        {

            //Create a new damage object, before sending it to the player
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce,
            };
            if (Time.time - lastCool > coolTime)
            {
                lastCool = Time.time;
                monsterAttackSoundEffect.Play();
            }

            coll.SendMessage("ReceiveDamage", dmg);

            //Debug.Log(coll.name);

        }
    }
}
