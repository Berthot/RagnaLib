using System.Collections.Generic;

namespace RagnaLib.Wrapper.ModelsAPI
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<RagnarokPrideMonster>(myJsonResponse); 
    public class Attack
    {
        public int minimum { get; set; }
        public int maximum { get; set; }
    }

    public class MagicAttack
    {
        public int minimum { get; set; }
        public int maximum { get; set; }
    }

    public class Stats
    {
        public int attackRange { get; set; }
        public int level { get; set; }
        public int health { get; set; }
        public int sp { get; set; }
        public int str { get; set; }
        public int @int { get; set; }
        public int vit { get; set; }
        public int dex { get; set; }
        public int agi { get; set; }
        public int luk { get; set; }
        public int rechargeTime { get; set; }
        public int atk1 { get; set; }
        public int atk2 { get; set; }
        public Attack attack { get; set; }
        public MagicAttack magicAttack { get; set; }
        public int defense { get; set; }
        public int baseExperience { get; set; }
        public int jobExperience { get; set; }
        public int aggroRange { get; set; }
        public int escapeRange { get; set; }
        public double movementSpeed { get; set; }
        public double attackSpeed { get; set; }
        public double attackedSpeed { get; set; }
        public int element { get; set; }
        public int scale { get; set; }
        public int race { get; set; }
        public int magicDefense { get; set; }
        public int hit { get; set; }
        public int flee { get; set; }
        public string ai { get; set; }
        public int mvp { get; set; }
        public int @class { get; set; }
        public int attr { get; set; }
    }

    public class Slave
    {
        public int id { get; set; }
        public int idx { get; set; }
        public int amount { get; set; }
    }

    public class Metamorphosi
    {
        public int id { get; set; }
        public int amount { get; set; }
    }

    public class Drop
    {
        public int itemId { get; set; }
        public int chance { get; set; }
        public bool stealProtected { get; set; }
        public string serverTypeName { get; set; }
    }

    public class Mvpdrop
    {
        public int itemId { get; set; }
        public int chance { get; set; }
        public bool stealProtected { get; set; }
        public string serverTypeName { get; set; }
    }

    public class Spawn
    {
        public string mapname { get; set; }
        public int amount { get; set; }
        public int respawnTime { get; set; }
    }

    public class Skill
    {
        public int idx { get; set; }
        public int skillId { get; set; }
        public string status { get; set; }
        public int level { get; set; }
        public int chance { get; set; }
        public int casttime { get; set; }
        public int delay { get; set; }
        public bool interruptable { get; set; }
        public object changeTo { get; set; }
        public object condition { get; set; }
        public object conditionValue { get; set; }
        public object sendType { get; set; }
        public object sendValue { get; set; }
    }

    public class PropertyTable
    {
        public int _0 { get; set; }
        public int _1 { get; set; }
        public int _2 { get; set; }
        public int _3 { get; set; }
        public int _4 { get; set; }
        public int _5 { get; set; }
        public int _6 { get; set; }
        public int _7 { get; set; }
        public int _8 { get; set; }
        public int _9 { get; set; }
    }

    public class RagnarokPrideMonster
    {
        public int id { get; set; }
        public string dbname { get; set; }
        public string name { get; set; }
        public Stats stats { get; set; }
        public List<object> spawnSet { get; set; }
        public List<Slave> slaves { get; set; }
        public List<Metamorphosi> metamorphosis { get; set; }
        public List<string> sounds { get; set; }
        public List<int> questObjective { get; set; }
        public List<Drop> drops { get; set; }
        public List<Mvpdrop> mvpdrops { get; set; }
        public List<Spawn> spawn { get; set; }
        public List<Skill> skill { get; set; }
        public PropertyTable propertyTable { get; set; }
    }
}