using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetDevPack.Security.Jwt.Core.Interfaces;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using NSE.Identidade.API.Models;
using NSE.WebAPI.Core.Identidade;
using NSE.WebAPI.Core.Usuario;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NSE.Identidade.API.Services
{
    public class AuthService
    {
        public readonly SignInManager<IdentityUser> SignInManager;
        public readonly UserManager<IdentityUser> UserManager;
        private readonly AppSettings _appSettings;
        private readonly AppTokenSettings _appTokenSettings;
        private readonly ApplicationDbContext _context;

        private readonly IJwtService _jwksService;
        private readonly IAspNetUser _aspNetUser;

        public AuthService(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IOptions<AppSettings> appSettings,
            IOptions<AppTokenSettings> appTokenSettingsSettings,
            ApplicationDbContext context,
            IJwtService jwksService,
            IAspNetUser aspNetUser)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            _appSettings = appSettings.Value;
            _appTokenSettings = appTokenSettingsSettings.Value;
            _jwksService = jwksService;
            _aspNetUser = aspNetUser;
            _context = context;
        }

        public async Task<UsuarioRespostaLogin> GerarJwt(string email)
        {
            var user = await UserManager.FindByEmailAsync(email);
            var claims = await UserManager.GetClaimsAsync(user);

            var identityClaims = await ObterClaimsUsuario(claims, user);
            string encodedToken = await CodificarToken(identityClaims);

            var refreshToken = await GerarRefreshToken(email);

            return ObterRespostaToken(user, claims, encodedToken, refreshToken);
        }

        public async Task<RefreshToken?> ObterRefreshToken(Guid refreshToken)
        {
            var token = await _context.RefreshTokens.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Token == refreshToken);

            return token is not null && token.ExpirationDate.ToLocalTime() > DateTime.Now
                ? token
                : null;

            //return token is not null && token.ExpirationDate > DateTime.UtcNow
            //    ? token
            //    : null;
        }

        private async Task<ClaimsIdentity> ObterClaimsUsuario(IList<Claim> claims, IdentityUser user)
        {
            var userRoles = await UserManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            AdicionarRolesComoClaims(claims, userRoles);

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            return identityClaims;


            static long ToUnixEpochDate(DateTime date)
                => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);

            static void AdicionarRolesComoClaims(IList<Claim> claims, IList<string> roles)
            {
                foreach (string userRole in roles)
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
            }
        }

        private async Task<string> CodificarToken(ClaimsIdentity identityClaims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Chave/secret é gerada de forma aleatória
            var key = await _jwksService.GetCurrentSigningCredentials();

            // O emissor será o Host onde este servidor de autenticação/identidade está hospedado (é o próprio endpoint da API)
            var currentIssuer = $"{_aspNetUser.ObterHttpContext().Request.Scheme}://{_aspNetUser.ObterHttpContext().Request.Host}";

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = currentIssuer,
                //Audience = _appSettings.ValidoEm,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = key
            });

            string encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

        private static UsuarioRespostaLogin ObterRespostaToken(IdentityUser user, IList<Claim> claims, string encodedToken, RefreshToken refreshToken)
        {
            return new UsuarioRespostaLogin
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(1).TotalSeconds,
                UsuarioToken = new UsuarioToken
                {
                    Id = user.Id,
                    Email = user.Email,
                    Claims = claims.Select(c => new UsuarioClaim
                    {
                        Type = c.Type,
                        Value = c.Value
                    })
                },
                RefreshToken = refreshToken.Token
            };
        }

        private async Task<RefreshToken> GerarRefreshToken(string email)
        {
            var refreshToken = new RefreshToken
            {
                Username = email,
                ExpirationDate = DateTime.UtcNow.AddHours(_appTokenSettings.RefreshTokenExpiration)
            };

            _context.RefreshTokens.RemoveRange(_context.RefreshTokens.Where(u => u.Username == email));
            await _context.RefreshTokens.AddAsync(refreshToken);

            await _context.SaveChangesAsync();

            return refreshToken;
        }
    }
}
