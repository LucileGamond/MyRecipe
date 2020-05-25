using Data;
using System;


namespace Service
{
    public interface IUserProfileService
    {
        UserProfileEntity GetUserProfile(Guid id);
    }
}
