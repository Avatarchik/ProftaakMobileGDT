namespace Assets.Scripts
{
    using System.Collections.Generic;

    using Assets.Scripts.Enhancements;

    public class Player
    {
        public static Player Instance = new Player();

        public string PlayerName { get; set; }
        public string IdeaName { get; set; }

        // Category { get; set; }

        public uint UnusedSkillPoints { get; set; }

        public uint KnowledgeSkills { get; set; }
        public uint PresentationSkills { get; set; }
        public uint MediaSkills { get; set; }

        // kan eigenlijk ook alleen de naam zijn ( EnhancementType )
        public List<Enhancement> UnlockedEnhancements { get; set; }

        public Player()
        {
            this.UnlockedEnhancements = new List<Enhancement>();
        }
    }
}
