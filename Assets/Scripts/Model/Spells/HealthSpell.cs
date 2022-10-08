using System;

namespace Model.Spells
{
    public class HealthSpell : Spell
    {
        private const float PercentOfAdd = 0.25f;
        
        public float CountOfRestoreHealth { get; private set; }

        public HealthSpell(int maxLevel) : base(maxLevel)
        {
            CountOfRestoreHealth = 20f;
        }

        public override void Accept(ISpellVisitor spellVisitor)
        {
            spellVisitor.UseSpell(this);
        }
    }
}