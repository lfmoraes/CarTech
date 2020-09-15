namespace CarTech.Infra.Email
{
    public class AuthMessageSenderOptions
    {
        public const string AuthMessage = "AuthMessage";

        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
