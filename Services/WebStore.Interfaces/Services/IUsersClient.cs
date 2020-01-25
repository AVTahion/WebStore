using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using WebStore.Domain.Entities.Identity;

namespace WebStore.Interfaces.Services
{
    public interface IUsersClient :
        IUserRoleStore<User>,
        IUserPasswordStore<User>,
        IUserPhoneNumberStore<User>,
        IUserEmailStore<User>,
        IUserClaimStore<User>,
        IUserTwoFactorStore<User>,
        IUserLoginStore<User>,
        IUserLockoutStore<User>
    {
    }
}
