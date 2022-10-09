using System;

namespace Model.Spells
{
    public abstract class Spell : Transformable
    {
        public abstract void Accept(ISpellVisitor spellVisitor);
    }
}