namespace TCO.Finportal.Infrastructure.Email.Smtp
{
    public class EmailOptions
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
    }
}
