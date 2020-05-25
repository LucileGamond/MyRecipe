using Data;
using Repository;
using System;
using System.Collections.Generic;


namespace Service
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> userRepository;
        private IRepository<UserProfileEntity> userProfileRepository;

        public UserService(IRepository<UserEntity> userRepository, IRepository<UserProfileEntity> userProfileRepository)
        {
            this.userRepository = userRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public IEnumerable<UserEntity> GetUsers()
        {
            return userRepository.GetAll();
        }

        public UserEntity GetUser(Guid id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(UserEntity user)
        {
            userRepository.Insert(user);
        }
        public void UpdateUser(UserEntity user)
        {
            

        }

        public void DeleteUser(Guid id)
        {
            UserProfileEntity userProfile = userProfileRepository.Get(id);
            userProfileRepository.Remove(userProfile);
            UserEntity user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }
    }
}
