namespace RagnaLib.Domain.Entities
{
    public class ItemMoveInfo
    {
        public bool Drop { get; set; }
        public bool Trade { get; set; }
        public bool Store { get; set; }
        public bool Cart { get; set; }
        public bool Sell { get; set; }
        public bool Rodex { get; set; }
        public bool Auction { get; set; }
        public bool GuildStore { get; set; }
    }
}