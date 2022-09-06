﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Api.Controllers
{
    internal class TokenGenerator
    {
        public static string GenerateTokenJWT(string mail)
        {
            // Valores del web config
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_KEY"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_KEY"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_MINUTES"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));


            //Tipo de encriptacion
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //Encriptacion por email
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, mail) });

            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            // Creacion de token con parametros
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(

                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jstTokenString = tokenHandler.WriteToken(jwtSecurityToken);


            return jstTokenString;
        }
    }
}