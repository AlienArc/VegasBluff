namespace Bluff.Helpers
{
    public enum TrackSelectionPreference
    {
        /// <summary>
        /// Indicates to only match with selected events
        /// </summary>
        OnlySelected,
        /// <summary>
        /// Indicates that if there are selected event to only match selected; otherwise return all events
        /// </summary>
        PreferSelected,
        /// <summary>
        /// Indicates to match all events
        /// </summary>
        All
    }
}