namespace Settings.Npc
{
    public interface INpcSettings
    {
        float DestinationChooseMinRadius { get; }
        float DestinationChooseMaxRadius { get; }
        float DestinationCheckDistance { get; }
    }
}