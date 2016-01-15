namespace Assets.Scripts.Enhancements
{
    public interface IUpgrade
    {
        string Name { get; set; }
        uint RequiredPoints { get; set; }

        //The method that executes the upgrade (Returns false if upgrade can't be done, true if it can be done)
        bool Upgrade();

    }
}
