using DSportConnect.Models.User;
using DSportConnect.Repositories.Security;
using Entity.Service;
using Entity.Service.User;
using MongoDB.Driver;
using System.Security.Cryptography;

namespace DSportConnect.Repositories.User
{
    public class OAuth2Repository : IOAuth2Repository
    {
        private readonly IMongoCollection<OAuth2> _oauth2Collection;
        private readonly IInformationRepository _informationRepository;

        public OAuth2Repository(IMongoClient mongoClient, string databaseName, IInformationRepository informationRepository)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _oauth2Collection = database.GetCollection<OAuth2>("OAuth2");
            _informationRepository = informationRepository;
        }

        #region GetByRefreshTokenAsync
        public async Task<OAuth2> GetByUsernameAsync(Entity.Service.User.LoginRequest request)
        {
            return await _oauth2Collection.Find(u => u.Username == request.Username).FirstOrDefaultAsync();
        }
        #endregion

        #region GetByRefreshTokenAsync
        public async Task<OAuth2> GetByRefreshTokenAsync(string refreshToken)
        {
            return await _oauth2Collection.Find(u => u.RefreshToken == refreshToken).FirstOrDefaultAsync();
        }
        #endregion

        #region SaveAsync
        public async Task SaveAsync(OAuth2Request oAuth2)
        {
            OAuth2 user;
            OAuth2 auth = await _oauth2Collection.Find(u => u.Username == oAuth2.Username).FirstOrDefaultAsync();
            if (auth ==  null)
            {
                user = new OAuth2()
                {
                    Id = Guid.NewGuid(),
                    Username = oAuth2.Username,
                    RefreshTokenExpiryTime = oAuth2.RefreshTokenExpiryTime,
                    RefreshToken = oAuth2.RefreshToken
                };
            }
            else
            {
                user = new OAuth2()
                {
                    Id = auth.Id,
                    Username = oAuth2.Username,
                    RefreshTokenExpiryTime = oAuth2.RefreshTokenExpiryTime,
                    RefreshToken = oAuth2.RefreshToken
                };
            }
            var filter = Builders<OAuth2>.Filter.Eq(u => u.Id, user.Id);
            await _oauth2Collection.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
        #endregion

        #region ResendVerificationCodeAsync
        public async Task ResendVerificationCodeAsync(string email, string codeVerified)
        {
            LoginRequest loginRequest = new LoginRequest()
            {
                Username = email,
                Password = ""
            };
            UserInformation _user = await _informationRepository.GetUserPasswordAsync(loginRequest);
            _user.CodeVerified = codeVerified;
            await _informationRepository.UpdateUserAsync(_user.Id.ToString(), _user);
        }
        #endregion
    }
}
