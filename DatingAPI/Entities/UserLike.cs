namespace DatingAPI.Entities
{
    public class UserLike
    {
        public Appuser SourceUser { get; set; }
        public int SourceUserId { get; set; }
        public Appuser TargetUser { get; set; }
        public int TargetUserId { get; set; }

    }
}
