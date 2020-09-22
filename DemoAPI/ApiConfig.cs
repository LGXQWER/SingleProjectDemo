using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI
{
    public class ApiConfig
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }
        /// <summary>
        /// API信息
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApis()
        {
            return new[]
            {
                new ApiScope(IdentityServerConstants.LocalApi.ScopeName),
                new ApiScope("manageApi", "Demo API with Swagger")
            };
        }
        /// <summary>
        /// 客服端信息
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Client> GetClients()
        {
            return new[]
            {
                new Client
                {
                    ClientId = "clientId",//客服端名称
                    ClientName = "Swagger UI for demo_api",//描述
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword ,//指定允许的授权类型（AuthorizationCode，Implicit，Hybrid，ResourceOwner，ClientCredentials的合法组合）。
                    AllowAccessTokensViaBrowser = true,//是否通过浏览器为此客户端传输访问令牌
                    AccessTokenLifetime = 3600*24,
                    AuthorizationCodeLifetime=3600*24,
                    ClientSecrets ={new Secret("secret".Sha256())},
                    //RedirectUris =
                    //{
                    //    "http://localhost:59152/oauth2-redirect.html"
                    //},
                    AllowedCorsOrigins = new string[]{ "http://localhost:9012", "http://101.133.234.110:21004",  "http://115.159.83.179:21004" },
                    AllowedScopes = { "manageApi", IdentityServerConstants.LocalApi.ScopeName }//指定客户端请求的api作用域。 如果为空，则客户端无法访问
                }
            };
        }
    }
}
