using DSportConnect.Models.Security;
using Entity.Service.Security;
using MongoDB.Driver;

namespace DSportConnect.Repositories.Security
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMongoCollection<Role> _rolesCollection;

        public RoleRepository(IMongoClient mongoClient, string databaseName, IAppObjectRepository objRepository)
        {
            var database = mongoClient.GetDatabase(databaseName);
            _rolesCollection = database.GetCollection<Role>("Roles");
        }

        #region GetAllRolesAsync
        public async Task<List<RoleGetResponse>> GetAllRolesAsync()
        {
            List<RoleGetResponse> roleGetResponses = new List<RoleGetResponse>();
            List<Role> list = await _rolesCollection.Find(_ => true).ToListAsync();
            if (list.Count < 1)
                return roleGetResponses;
            foreach (Role _rol in list)
            {
                RoleGetResponse roleGet = new RoleGetResponse
                {
                    Id = _rol.Id,
                    RoleName = _rol.RoleName,
                    Description = _rol.Description,
                    CreatedAt = DateTime.Now
                };
                foreach (Models.Security.Permission item in _rol.Permissions)
                {
                    roleGet.Permissions.Add(new Entity.Service.Security.Permission
                    {
                        Id = item.Id,
                        Actions = item.Actions,
                        ObjName = item.ObjName,
                    });
                }
                roleGetResponses.Add(roleGet);
            }
            return roleGetResponses;
        }
        #endregion

        #region GetRoleByIdAsync
        public async Task<RoleGetResponse?> GetRoleByIdAsync(string id)
        {
            Role? _rol = await _rolesCollection.Find(r => r.Id == Guid.Parse(id)).FirstOrDefaultAsync();
            if (_rol == null)
                return null;
            RoleGetResponse roleGet = new RoleGetResponse
            {
                Id = _rol.Id,
                RoleName = _rol.RoleName,
                Description = _rol.Description,
                CreatedAt = _rol.CreatedAt
            };
            foreach (Models.Security.Permission item in _rol.Permissions)
            {
                roleGet.Permissions.Add(new Entity.Service.Security.Permission
                {
                    Id = item.Id,
                    Actions = item.Actions,
                    ObjName = item.ObjName,
                });
            }
            return roleGet;
        }
        #endregion

        #region GetRoleByRoleNameAsync
        public async Task<RoleGetResponse?> GetRoleByRoleNameAsync(string roleName)
        {
            Role? _rol = await _rolesCollection.Find(r => r.RoleName == roleName).FirstOrDefaultAsync();
            if (_rol == null) 
                return null;
            RoleGetResponse roleGet = new RoleGetResponse
            {
                Id = _rol.Id,
                RoleName = _rol.RoleName,
                Description = _rol.Description,
                CreatedAt = _rol.CreatedAt
            };
            foreach (Models.Security.Permission item in _rol.Permissions)
            {
                roleGet.Permissions.Add(new Entity.Service.Security.Permission
                {
                    Id = item.Id,
                    Actions = item.Actions,
                    ObjName = item.ObjName,
                });
            }
            return roleGet;
        }
        #endregion

        #region CreateRoleAsync
        public async Task CreateRoleAsync(RoleRequest role)
        {
            Role _rol = new Role 
            { 
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                Description = role.Description,
                RoleName = role.RoleName
            };
            foreach (Entity.Service.Security.Permission item in role.Permissions)
            {
                _rol.Permissions.Add(new Models.Security.Permission
                {
                    Id = item.Id,
                    Actions = item.Actions,
                    ObjName = item.ObjName,
                });
            }
            await _rolesCollection.InsertOneAsync(_rol);
        }
        #endregion

        #region UpdateRoleAsync
        public async Task UpdateRoleAsync(string id, RoleRequest role)
        {
            Role _rol = new Role
            {
                Id = Guid.Parse(id),
                CreatedAt = DateTime.UtcNow,
                Description = role.Description,
                RoleName = role.RoleName
            };
            foreach (Entity.Service.Security.Permission item in role.Permissions)
            {
                _rol.Permissions.Add(new Models.Security.Permission
                {
                    Id = item.Id,
                    Actions = item.Actions,
                    ObjName = item.ObjName,
                });
            }
            await _rolesCollection.ReplaceOneAsync(r => r.Id == Guid.Parse(id), _rol);
        }
        #endregion

        #region DeleteRoleAsync
        public async Task DeleteRoleAsync(string id) =>
            await _rolesCollection.DeleteOneAsync(r => r.Id == Guid.Parse(id));
        #endregion
    }
}
