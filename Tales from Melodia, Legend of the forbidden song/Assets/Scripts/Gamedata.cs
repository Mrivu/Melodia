using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Gamedata
{

    public static class Position1
    {
        static Sprite[] Position1Sprites = Resources.LoadAll<Sprite>("Artwork/EGsprites");

        public static Sprite idle = Position1Sprites.Single(s => s.name == "EGsprites_Idle");
        public static Sprite attacking = Position1Sprites.Single(s => s.name == "EGsprites_Attacking");
        public static Sprite attack1 = Position1Sprites.Single(s => s.name == "EGsprites_Attacked");
        public static Sprite dodge = Position1Sprites.Single(s => s.name == "EGsprites_Dodge");
        public static Sprite hit = Position1Sprites.Single(s => s.name == "EGsprites_Hit");
        public static Sprite killed = Position1Sprites.Single(s => s.name == "EGsprites_Killed");
        public static Sprite idleFlow = Position1Sprites.Single(s => s.name == "EGsprites_IdleFlow");
        public static Sprite attackingFlow = Position1Sprites.Single(s => s.name == "EGsprites_AttackingFlow");
        public static Sprite attack1Flow = Position1Sprites.Single(s => s.name == "EGsprites_AttackedFlow");
        public static Sprite dodgeFlow = Position1Sprites.Single(s => s.name == "EGsprites_DodgeFlow");
        public static Sprite hitFlow = Position1Sprites.Single(s => s.name == "EGsprites_HitFlow");
        public static Sprite killedFlow = Position1Sprites.Single(s => s.name == "EGsprites_KilledFlow");

        public static int Maxhp = 21;
        public static int Hp = 21;
        public static int Maxflow = 7;
        public static int Flow = 7;
        public static int Speed = 1;
        public static float Dodge = 5.0f;
        public static string Class = "electric_guitar";
        public static int Level = 1;

        public static bool Characterslotted = true;

        //Selected abilities
        
        public static class Ability1
        {
            public static string Color = "red";

            public static string Name = "Slice";
            public static int Mindmg = 3;
            public static int Maxdmg = 7;
            public static float Hitchance = 85.0f;
            public static int StatusID = 0;
            public static float StatusChance = 0;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 0;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability2
        {
            public static string Color = "red";

            public static string Name = "Smash";
            public static int Mindmg = 4;
            public static int Maxdmg = 6;
            public static float Hitchance = 80.0f;
            public static int StatusID = 0;
            public static float StatusChance = 0;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 0;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability3
        {
            public static string Color = "blue";

            public static string Name = "Shock";
            public static int Mindmg = 1;
            public static int Maxdmg = 2;
            public static float Hitchance = 80.0f;
            public static int StatusID = 2;
            public static float StatusChance = 80.0f;
            public static int StatusStrenght = 1;
            public static int StatusDuration = 3;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = true;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability4
        {
            public static string Color = "blue";

            public static string Name = "Uppercut";
            public static int Mindmg = 2;
            public static int Maxdmg = 5;
            public static float Hitchance = 75.0f;
            public static int StatusID = 1;
            public static float StatusChance = 80.0f;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 1;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
    }

    public static class Position2
    {
        static Sprite[] Position2Sprites = Resources.LoadAll<Sprite>("Artwork/EGsprites");

        public static Sprite idle = Position2Sprites.Single(s => s.name == "EGsprites_Idle");
        public static Sprite attacking = Position2Sprites.Single(s => s.name == "EGsprites_Attacking");
        public static Sprite attack1 = Position2Sprites.Single(s => s.name == "EGsprites_Attacked");
        public static Sprite dodge = Position2Sprites.Single(s => s.name == "EGsprites_Dodge");
        public static Sprite hit = Position2Sprites.Single(s => s.name == "EGsprites_Hit");
        public static Sprite killed = Position2Sprites.Single(s => s.name == "EGsprites_Killed");

        public static int Maxhp = 21;
        public static int Hp = 21;
        public static int Maxflow = 7;
        public static int Flow = 0;
        public static int Speed = 1;
        public static float Dodge = 5.0f;
        public static string Class = "electric_guitar";
        public static int Level = 1;

        public static bool Characterslotted = false;

        //Selected abilities

        public static class Ability1
        {
            public static string Color = "red";

            public static string Name = "Slice";
            public static int Mindmg = 3;
            public static int Maxdmg = 7;
            public static float Hitchance = 85.0f;
            public static int StatusID = 0;
            public static float StatusChance = 0;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 0;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability2
        {
            public static string Color = "red";

            public static string Name = "Smash";
            public static int Mindmg = 4;
            public static int Maxdmg = 6;
            public static float Hitchance = 80.0f;
            public static int StatusID = 0;
            public static float StatusChance = 0;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 0;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability3
        {
            public static string Color = "blue";

            public static string Name = "Shock";
            public static int Mindmg = 1;
            public static int Maxdmg = 2;
            public static float Hitchance = 80.0f;
            public static int StatusID = 2;
            public static float StatusChance = 80.0f;
            public static int StatusStrenght = 1;
            public static int StatusDuration = 3;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = true;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
        public static class Ability4
        {
            public static string Color = "blue";

            public static string Name = "Uppercut";
            public static int Mindmg = 2;
            public static int Maxdmg = 5;
            public static float Hitchance = 75.0f;
            public static int StatusID = 1;
            public static float StatusChance = 80.0f;
            public static int StatusStrenght = 0;
            public static int StatusDuration = 1;
            public static int Flowbonus = 0;

            public static bool Hitrank1 = true;
            public static bool Hitrank2 = true;
            public static bool Hitrank3 = false;

            public static bool Hit1and2 = false;
            public static bool Hit2and3 = false;
            public static bool Hitall = false;
        }
    }


    //Combat data

    public static bool red = true;
    public static bool blue = true;
    public static bool yellow = false;
    public static bool green = false;

    public static class Enemy1
    {
        static Sprite[] Enemy1Sprites = Resources.LoadAll<Sprite>("Artwork/1note");

        public static Sprite idle = Enemy1Sprites.Single(s => s.name == "1note_Idle");
        public static Sprite attacking = Enemy1Sprites.Single(s => s.name == "1note_Idle");
        public static Sprite attack1 = Enemy1Sprites.Single(s => s.name == "1note_attack");
        public static Sprite dodge = Enemy1Sprites.Single(s => s.name == "1note_Idle");
        public static Sprite hit = Enemy1Sprites.Single(s => s.name == "1note_hit");
        public static Sprite killed = Enemy1Sprites.Single(s => s.name == "1note_killed");
        //Wont find sprites

        public static int Maxhp = 18;
        public static int Hp = 18;
        public static int Speed = 2;
        public static string Name = "Note soldier";
        public static float Dodge = 0.0f;

        public static bool Enemyslotted = true;

        public static int HasStatusID = 0;
        public static int StatusStrenght = 0;
        public static int StatusDuration = 0;

        public static int AI = 1;

        public static class AIability1
        {
            public static int Probability = 15; //out of 20

            public static int mindmg = 3;
            public static int maxdmg = 7;
            public static float hit = 100f;

            public static int flowreduction = 0;
        }
        public static class AIability2
        {
            public static int Probability = 5; //out of 20

            public static int mindmg = 2;
            public static int maxdmg = 5;
            public static float hit = 100f;

            public static int flowreduction = 3;
        }
        public static class AIability3
        {
            public static int Probability = 0; //out of 20

            public static int mindmg = 0;
            public static int maxdmg = 0;

            public static float hit = 100f;

            public static int flowreduction = 0;
        }
        public static class AIability4
        {
            public static int Probability = 0; //out of 20

            public static int mindmg = 0;
            public static int maxdmg = 0;

            public static float hit = 100f;

            public static int flowreduction = 0;
        }
    }
}
