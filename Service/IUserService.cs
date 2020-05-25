using System;
using System.Collections.Generic;
using Data;

namespace Service
{
    public interface IUserService
    {
        IEnumerable<UserEntity> GetUsers();
        UserEntity GetUser(Guid id);
        void InsertUser(UserEntity user);
        void UpdateUser(UserEntity user);
        void DeleteUser(Guid id);
    }
}
