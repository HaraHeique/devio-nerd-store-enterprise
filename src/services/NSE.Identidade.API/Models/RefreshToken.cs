namespace NSE.Identidade.API.Models
{
    public class RefreshToken
    {
        public RefreshToken()
        {
            Id = Guid.NewGuid();
            Token = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Username { get; set; } // No caso deste App UserName e Email são iguais
        public Guid Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
