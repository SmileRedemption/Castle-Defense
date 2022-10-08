namespace Model.Spells
{
    public class RageSpell : Spell
    {
        public float CountOfSpeedUp { get; private set; }

        public RageSpell(int maxLevel) : base(maxLevel)
        {
            CountOfSpeedUp = 2;
        }

        public override void Accept(ISpellVisitor spellVisitor)
        {
            spellVisitor.UseSpell(this);
        }
    }
}