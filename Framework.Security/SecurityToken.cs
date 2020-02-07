namespace Framework.Security
{
    public class SecurityToken
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public int[] Operations { get; set; }
    }
}
