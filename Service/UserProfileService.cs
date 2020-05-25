using Data;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class UserProfileService : IUserProfileService
    {
        private IRepository<UserProfileEntity> userProfileRepository;

        public UserProfileService(IRepository<UserProfileEntity> userProfileRepository)
        {
            this.userProfileRepository = userProfileRepository;
        }

        public UserProfileEntity GetUserProfile(Guid id)
        {
            return userProfileRepository.Get(id);
        }
    }
}
