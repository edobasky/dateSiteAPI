namespace DatingAPI.Entities
{
    public class Appuser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[]  PasswordHarsh  { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
