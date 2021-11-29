namespace TCO.Finportal.Shared.UseCases.Users.Shared
{
    public class EsfUserProfileDto
    {
        public bool UsernameSpecified { get; set; }

        public bool PasswordSpecified { get; set; }

        public bool AuthCertificateUploaded { get; set; }

        public bool SignCertificateUploaded { get; set; }

        public bool ReadyForAuth { get; set; }

        public bool ReadyForSign { get; set; }
    }
}
