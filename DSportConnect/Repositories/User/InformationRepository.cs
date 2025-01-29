using DSportConnect.Models.Security;
using DSportConnect.Models.Sport;
using DSportConnect.Models.User;
using DSportConnect.Repositories.Security;
using Entity.AppSettings;
using Entity.Service.Security;
using Entity.Service.Sport;
using Entity.Service.User;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSportConnect.Repositories.User
{
    public class InformationRepository : IInformationRepository
    {
        private readonly IMongoCollection<UserInformation> _userCollection;
        private readonly IRoleRepository _rolRepository;
        private readonly UserRol _userRol;

        public InformationRepository(IMongoClient mongoClient, string databaseName, IRoleRepository rolRepository, IOptions<UserRol> userRolOptions)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _userCollection = database.GetCollection<UserInformation>("Users");
            _rolRepository = rolRepository;
            _userRol = userRolOptions.Value;
        }

        #region CreateUserAsync
        public async Task CreateUserAsync(CreateUserRequest user, string codeVerified)
        {
            UserInformation userInformation = new UserInformation() 
            {
                Id = Guid.NewGuid(),
                Mail = user.Mail,
                Password = user.Password,
                Roles = new List<string>(),
                CodeVerified = codeVerified,
                CreatedAt = DateTime.UtcNow
            };
            userInformation.Roles.Add(_userRol.Principal);
            userInformation.PersonalInformation = new UserPersonalInformation() 
            { 
                DocumentType = user.DocumentType,
                DocumentNumber = user.DocumentNumber,
                Names = user.Names,
                LastName = user.LastName,
                FirstName = user.FirstName,
                Birthdate = user.Birthdate,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber
            };
            await _userCollection.InsertOneAsync(userInformation);
        }
        #endregion

        #region UpdateUserAsync
        public async Task UpdateUserAsync(string id, UserInformation user)
        {
            await _userCollection.ReplaceOneAsync(r => r.Id == Guid.Parse(id), user);
        }
        #endregion

        #region UserExistsAsync
        public async Task<bool> UserExistsAsync(CreateUserRequest user)
        {
            UserInformation? _user = await _userCollection.Find(u => u.Mail.ToUpper().Equals(user.Mail.ToUpper())).FirstOrDefaultAsync();
            if (_user != null)
                throw new ArgumentException("El Mail ya esta registrado.");
            _user = await _userCollection.Find(u => u.PersonalInformation.DocumentType.ToUpper().Equals(user.DocumentType.ToUpper()) 
                                                && u.PersonalInformation.DocumentNumber.ToUpper().Equals(user.DocumentNumber.ToUpper())).FirstOrDefaultAsync();
            if (_user != null)
                throw new ArgumentException("El número de documento y tipo de documento ya estan registrado.");
            return true;
        }
        #endregion

        #region GetUserPasswordAsync
        public async Task<UserInformation> GetUserPasswordAsync(LoginRequest loginRequest)
        {
            UserInformation? _user = await _userCollection.Find(u => u.Mail.ToUpper().Equals(loginRequest.Username.ToUpper())).FirstOrDefaultAsync();
            if (_user == null)
                throw new ArgumentException("Usuario no registrado.");
            return _user;
        }
        #endregion

        #region ForgotPasswordAsync
        public async Task ForgotPasswordAsync(string username, string newPassword)
        {
            UserInformation? _user = await _userCollection.Find(u => u.Mail.ToUpper().Equals(username.ToUpper())).FirstOrDefaultAsync();
            if (_user == null)
                throw new ArgumentException("Usuario no registrado.");
            _user.Password = newPassword;
            await _userCollection.ReplaceOneAsync(r => r.Id == _user.Id, _user);
        }
        #endregion

        #region GetUserByDocumentNumberAsync
        public async Task<UserInformation> GetUserByDocumentNumberAsync(string documentNumber)
        {
            return await _userCollection.Find(u => u.PersonalInformation.DocumentNumber == documentNumber).FirstOrDefaultAsync();
        }
        #endregion
    }
}
