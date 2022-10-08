using System;

namespace Model.Spells
{
    public abstract class Spell : Transformable
    {
        public int MaxLevel { get; }
        public int CurrentLevel { get; private set; }
        public int Price { get; private set; }

        public abstract void Accept(ISpellVisitor spellVisitor);
        protected Spell(int maxLevel)
        {
            MaxLevel = maxLevel;
            CurrentLevel = 1;
        }
        
        public void UpLevel()
        {
            if (CurrentLevel == MaxLevel)
                throw new InvalidOperationException();

            CurrentLevel += 1;
        }
    }
}