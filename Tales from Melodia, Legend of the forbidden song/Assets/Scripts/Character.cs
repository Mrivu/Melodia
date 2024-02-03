using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Maxhp;
    public int Hp;
    public int Maxflow;
    public int Flow;
    public int Speed;
    public float Dodge;
    public string Class;
    public int Level;

    public bool Characterslotted;
    public int Characternumber;

    public float Flowdamage = 1.00f;
    public float Flowhitchance = 0f;
    public float Flowstatuschance = 0f;
    public int FlowDur = 0;
    public bool InFlow = false;

    public Vector2 podiumPosition;

    public bool hasTurn;

    private void Awake()
    {
        if (Characternumber == 1)
        {
            Maxhp = Gamedata.Position1.Maxhp;
            Hp = Gamedata.Position1.Hp;
            Maxflow = Gamedata.Position1.Maxflow;
            Flow = Gamedata.Position1.Flow;
            Speed = Gamedata.Position1.Speed;
            Dodge = Gamedata.Position1.Dodge;
            Class = Gamedata.Position1.Class;
            Level = Gamedata.Position1.Level;

            Characterslotted = Gamedata.Position1.Characterslotted;
        }

        if (Characternumber == 2)
        {
            Maxhp = Gamedata.Position2.Maxhp;
            Hp = Gamedata.Position2.Hp;
            Maxflow = Gamedata.Position2.Maxflow;
            Flow = Gamedata.Position2.Flow;
            Speed = Gamedata.Position2.Speed;
            Dodge = Gamedata.Position2.Dodge;
            Class = Gamedata.Position2.Class;
            Level = Gamedata.Position2.Level;

            Characterslotted = Gamedata.Position2.Characterslotted;
        }
    }

    void Start()
    {
        if (Characterslotted)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<AnimationData>().idle;
        }
    }

    
    void Update()
    {
    }
}
