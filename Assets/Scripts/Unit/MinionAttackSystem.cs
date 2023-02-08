using AbstractClasses;

namespace Unit
{
    public class MinionAttackSystem : AttackSystem
    {
        public float AttackDistance = .15f;
        public float TimeBetweenAttacks = 1.5f;
        public float NextAttackTime = float.MinValue;
    }
}
