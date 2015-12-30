using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Skill : MonoBehaviour {

    public GameObject upgradeObj;
    [HideInInspector]
    public Skill[] requiredSkills;

    private Button unlockButton;

    private int _RequiredUnlocks;

    public int RequiredUnlocks
    {
        get { return _RequiredUnlocks; }
        set
        {
            _RequiredUnlocks = value;
            if (_RequiredUnlocks >= requiredSkills.Length)
            {
                
                unlocked = true;
                unlockButton.interactable = true;
                unlockButton.image.sprite = regularImg;
            }
        }
    }

    [HideInInspector]
    public Skill unlockSkill;

    [SerializeField]
    private GameManager gm;

    [SerializeField]
    private IUpgrade upgrade;
    private Text upgradeName;

    [SerializeField]
    private bool upgraded;
    private bool unlocked;


    //Button Images
    public Sprite regularImg, unlockedImg, lockedImg;

	// Use this for initialization
	void Start () {

        unlocked = false;
        upgraded = false;

	    upgradeName = this.GetComponentInChildren<Text>();

	    unlockButton = this.GetComponent<Button>();
        unlockButton.image.sprite = regularImg;

        upgrade = upgradeObj.GetComponent<IUpgrade>();
        upgradeName.text = upgrade.Name;

        foreach(Skill s in requiredSkills)
        {
            s.unlockSkill = this;
            //_RequiredUnlocks += 1;
        }

        if (this.requiredSkills.Length != 0)
        {
            unlockButton.image.sprite = lockedImg;
            unlockButton.interactable = false;

        }

    }
    
    public void UnlockSkill()
    {
        if (upgrade.Upgrade() && !upgraded)
        {
            gm.skillpoints -= upgrade.RequiredPoints;
            upgraded = true;
            unlockButton.image.sprite = unlockedImg;

            if (unlockSkill != null)
            {
                unlockSkill.RequiredUnlocks += 1;
            }
        }

    }
	
	// Update is called once per frame
	void Update () {

	
	}
}
