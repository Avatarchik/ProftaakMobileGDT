﻿namespace Assets.Scripts
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

        private int _knowledgeSkills;
        public int KnowledgeSkills
        {
            get { return this._knowledgeSkills; }
            set
            {
                if (value < 0)
                    this._knowledgeSkills = 0;
                else
                    this._knowledgeSkills = value;
            }
        }
        private int _presentationSkills;
        public int PresentationSkills
        {
            get { return this._presentationSkills; }
            set
            {
                if (value < 0)
                    this._presentationSkills = 0;
                else
                    this._presentationSkills = value;
            }
        }
        private int _mediaSkills;
        public int MediaSkills
        {
            get { return this._mediaSkills; }
            set
            {
                if (value < 0)
                    this._mediaSkills = 0;
                else
                    this._mediaSkills = value;
            }
        }

        // kan eigenlijk ook alleen de naam zijn ( EnhancementType )
        public List<Enhancement> UnlockedEnhancements { get; set; }

        public Player()
        {
            this.UnlockedEnhancements = new List<Enhancement>();
            this.UnusedSkillPoints = 1;
        }
    }
}
