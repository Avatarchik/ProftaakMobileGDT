namespace Assets.Scripts
{
    using System.Collections.Generic;

    using Assets.Scripts.Enhancements;

    public enum PlayerSkill { Knowledge, Presentation, Media };

    public class Player
    {
        public static Player Instance = new Player();

        public string PlayerName { get; set; }
        public string IdeaName { get; set; }

        // Category { get; set; }

        public uint UnusedSkillPoints { get; set; }

        public int KnowledgeSkills { get; set; }
        public int PresentationSkills { get; set; }
        public int MediaSkills { get; set; }

        // kan eigenlijk ook alleen de naam zijn ( EnhancementType )
        public List<Enhancement> UnlockedEnhancements { get; set; }

        public Player()
        {
            this.UnlockedEnhancements = new List<Enhancement>();
            // TODO: Remove
            this.UnusedSkillPoints = 10;
        }
    }
}
