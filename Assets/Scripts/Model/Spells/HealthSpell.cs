using System;

namespace Model.Spells
{
    public class HealthSpell : Spell
    {
        public float CountOfRestoreHealth { get; private set; }

        public HealthSpell()
        {
            CountOfRestoreHealth = 20f;
        }

        public override void Accept(ISpellVisitor spellVisitor)
        {
            spellVisitor.UseSpell(this);
        }
    }
}