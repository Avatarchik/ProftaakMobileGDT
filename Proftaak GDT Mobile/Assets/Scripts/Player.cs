namespace Assets.Scripts
{
    using System.Collections.Generic;

    using Assets.Scripts.Enhancements;

    public enum PlayerSkill { Knowledge = 0, Presentation = 1, Media = 2 };

    public enum IdeaCategory { Technology, Design, Entertainment, Global_Issues, Education };

    public class Player
    {
        public static Player Instance = new Player();

        public string PlayerName { get; set; }
        public string IdeaName { get; set; }

        public IdeaCategory Category { get; set; }

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
            this.UnusedSkillPoints = 1;
        }
    }
}
