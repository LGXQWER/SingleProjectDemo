using DemoAPI.Services.UserService;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Authentication
{
    public class CustomResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly IUserService _userService;

        public CustomResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var dto = await _userService.ValidateCredentials(context.UserName, context.Password);
            if (dto!=null)
            {
                context.Result = new GrantValidationResult(
                   dto.Id.ToString(),
                   "pwd",
                   DateTime.Now);
            }
            else
            {
                //验证失败
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "用户名密码错误");
            }
        }
    }
}
