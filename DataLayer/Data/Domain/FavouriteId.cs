using System;

namespace CloudCore.Domain
{
    public class FavouriteId
    {
        public int UserId { get; set; }
        public Guid Reference { get; set; }

        public override string ToString()
        {
            return string.Format("{0}:{1}", UserId, Reference);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FavouriteId))
                return false;

            var item = (FavouriteId) obj;

            return item.UserId == UserId & item.Reference == Reference;
        }

        public override int GetHashCode()
        {
            var hash = 13;

            hash = (hash * 7) + UserId.GetHashCode();
            hash = (hash * 7) + Reference.GetHashCode();

            return hash;
        }
    }
}