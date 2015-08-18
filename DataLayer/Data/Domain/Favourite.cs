using System;


namespace CloudCore.Domain
{
    [Serializable]
    public class Favourite
    {
        public new FavouriteId Id { get; set; }
        public FavouriteType Type { get; set; }
        public int ActionId { get; set; }
    }

    public enum FavouriteType
    {
        Menu = 0,
        Dashboard = 1
    }
}
