using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Services.UserService
{
    public class UserService : IUserService
    {
        public async Task<TestPhoneUser> ValidateCredentials(string nameorphone, string password)
        {
            var dto= TestUser.FirstOrDefault(c => c.Phone == nameorphone && password == c.PassWord);
            if (dto != null)
                return dto;
            else
                return null;
        }
        public class TestPhoneUser
        {
            /// <summary>
            /// 唯一标识
            /// </summary>
            public int Id { get; set; }
            /// <summary>
            /// 手机号
            /// </summary>
            public string Phone { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public string PassWord { get; set; }
        }
        public List<TestPhoneUser> TestUser = new List<TestPhoneUser>
        {
            new TestPhoneUser
            {
                Id=1,
                Phone="12345678911",
                PassWord="123qwe"
            },new TestPhoneUser
            {
                Id=2,
                Phone="123",
                PassWord="123qwe"
            }
        };
        
    }
}
