using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationData : MonoBehaviour
{
    public Sprite idle;
    public Sprite attacking;
    public Sprite attack1;
    public Sprite dodge;
    public Sprite hit;
    public Sprite killed;
    public Sprite idleFlow;
    public Sprite attackingFlow;
    public Sprite attack1Flow;
    public Sprite dodgeFlow;
    public Sprite hitFlow;
    public Sprite killedFlow;
    public Character character = null;
    public Enemy enemy = null;
    public bool IsCharacter;

    public void Awake()
    {
        if (gameObject.name == "Character1")
        {
            idle = Gamedata.Position1.idle;
            attacking = Gamedata.Position1.attacking;
            attack1 = Gamedata.Position1.attack1;
            dodge = Gamedata.Position1.dodge;
            hit = Gamedata.Position1.hit;
            killed = Gamedata.Position1.killed;
            idleFlow = Gamedata.Position1.idleFlow;
            attackingFlow = Gamedata.Position1.attackingFlow;
            attack1Flow = Gamedata.Position1.attack1Flow;
            dodgeFlow = Gamedata.Position1.dodgeFlow;
            hitFlow = Gamedata.Position1.hitFlow;
            killedFlow = Gamedata.Position1.killedFlow;
            character = gameObject.GetComponent<Character>();
        }

        if (gameObject.name == "Character2")
        {
            idle = Gamedata.Position2.idle;
            attacking = Gamedata.Position2.attacking;
            attack1 = Gamedata.Position2.attack1;
            dodge = Gamedata.Position2.dodge;
            hit = Gamedata.Position2.hit;
            killed = Gamedata.Position2.killed;
            character = gameObject.GetComponent<Character>();
        }

        if (gameObject.name == "Enemy1")
        {
            idle = Gamedata.Enemy1.idle;
            attacking = Gamedata.Enemy1.attacking;
            attack1 = Gamedata.Enemy1.attack1;
            dodge = Gamedata.Enemy1.dodge;
            hit = Gamedata.Enemy1.hit;
            killed = Gamedata.Enemy1.killed;
            enemy = gameObject.GetComponent<Enemy>();

        }
    }
}
