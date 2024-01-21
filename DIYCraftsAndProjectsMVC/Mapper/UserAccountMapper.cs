using DIYCraftsAndProjectsMVC.Models;
using DIYCraftsAndProjectsMVC.Models.BLModel;

namespace DIYCraftsAndProjectsMVC.Mapper
{
    public static class UserAccountMapper
    {
        public static User MapAccountToUser(Account account)
        {
            User user = new User
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                DateOfBirth = account.DateOfBirth,
                Email = account.Email,
                UserName = account.UserName,
                CountryId = account.CountryId,
                TypeId = 2,
                DateCreated = DateTime.Now,
                IsActive = true,
                Password = account.Password
            };

            return user;
        }
    }
}
