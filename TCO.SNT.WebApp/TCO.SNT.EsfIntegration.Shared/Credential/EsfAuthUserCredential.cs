namespace TCO.SNT.EsfIntegration.Shared.Credential
{
    public class EsfAuthUserCredential
    {
        public EsfAuthUserCredential(string username, string password, string authCertificate)
        {
            Username = username;
            Password = password;
            AuthCertificate = authCertificate;
        }

        public string Username { get; }

        public string Password { get; }

        public string AuthCertificate { get; }
    }
}
