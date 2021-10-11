using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Helpers;
using UtopiaCity.Models.Media;
using UtopiaCity.Models.Media.Account;
using UtopiaCity.Models.Media.Responses;
using BCryptNet = BCrypt.Net.BCrypt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using UtopiaCity.Models.Media.Requests;

namespace UtopiaCity.Services.Media
{
    public class AccountService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AccountService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        public async Task<Role> GetByName(string name)
        {
            return await _dbContext.Roles_.FirstOrDefaultAsync(x => x.Name.Equals(name));
        }

        public async Task<RegisterResponse> Register(RegisterRequest model)
        {
            if (await _dbContext.Users_.AnyAsync(x => x.Email == model.Email))
                throw new AppException("This email '" + model.Email + "' is already used");

            var user = _mapper.Map<User>(model);

            user.PasswordHash = BCryptNet.HashPassword(model.Password);

            user.Role = await _dbContext.Roles_.SingleAsync(x => x.Name == "User");
            
            await _dbContext.Users_.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<RegisterResponse>(user);
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _dbContext.Users_
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Email == model.Email);

            var employee = new Employee();

            if (user is null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                employee = await _dbContext.Employees_
                    .Include(x => x.Role)
                    .SingleOrDefaultAsync(x => x.Email == model.Email);

                if (employee is null || !BCryptNet.Verify(model.Password, employee.PasswordHash))
                    throw new AppException("Username or password is incorrect");

                return _mapper.Map<AuthenticateResponse>(employee);
            }

            return _mapper.Map<AuthenticateResponse>(user);
        }

        public async Task ChangePassword(ChangePasswordRequest model)
        {
            var user = await _dbContext.Users_
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Email == model.Email);

            if (user is null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                var employee = await _dbContext.Employees_
                    .Include(x => x.Role)
                    .SingleOrDefaultAsync(x => x.Email == model.Email);

                if (employee is null || !BCryptNet.Verify(model.Password, employee.PasswordHash))
                    throw new AppException("Username or password is incorrect");


                employee.PasswordHash = BCryptNet.HashPassword(model.Password);
                await _dbContext.SaveChangesAsync();
                
            }
            user.PasswordHash = BCryptNet.HashPassword(model.Password);
            await _dbContext.SaveChangesAsync();
        }
    }
}