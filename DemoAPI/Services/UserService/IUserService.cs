using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DemoAPI.Services.UserService.UserService;

namespace DemoAPI.Services.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// 用户验证
        /// </summary>
        /// <param name="nameorphone">用户名或者手机号</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        Task<TestPhoneUser> ValidateCredentials(string nameorphone, string password);
    }
}
