using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UtopiaCity.Data;
using UtopiaCity.Models.FireSystem;
using UtopiaCity.Models.FireSystem.ManagementSystemTransportAndEmployeess;

namespace UtopiaCity.Services.FireSystem
{
    public class FireMessageService
    {
        private readonly ApplicationDbContext _dbContext;

        public FireMessageService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<FireMessage> GetFireMessageById(string id)
        {
            return await _dbContext.FireMessage.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public virtual async Task<List<FireMessage>> GetFireMessages()
        {
            return await _dbContext.FireMessage.ToListAsync();
        }

        public async Task<FireMessage> AddFireMessage(FireMessage message)
        {
            _dbContext.Add(message);
            await _dbContext.SaveChangesAsync();
            return message;
        }

        public async Task UpdateFireMessage(FireMessage message)
        {
            _dbContext.Update(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFireMessage(FireMessage message)
        {
            _dbContext.Remove(message);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FireSafetyDepartment> GetFreeDepartmentAndChangeStatusOnBusy()
        {
            var department = await _dbContext.Departments.Where(d => d.DepartmentStatusEnum.Equals(DepartmentStatusEnum.Free)).FirstAsync();
            if(department != null)
            {
                var onTheRoadStatus = DepartmentStatusEnum.OnTheRoad;
                department.DepartmentStatusEnum = onTheRoadStatus;
                await _dbContext.SaveChangesAsync();
                return department;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<DepartureToThePlaceOfFire>> GetDepatures()
        {
            return await _dbContext.DeparturesToThePlaces.ToListAsync();
        }
        public async Task SetFreeStatusOnDepartment(FireSafetyDepartment department)
        {
            department.DepartmentStatusEnum = DepartmentStatusEnum.Free;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<DepartureToThePlaceOfFire> GetDepatureByFireMessage(FireMessage message)
        {
            var depature = await _dbContext.DeparturesToThePlaces.Where(d => d.FireMessage.Equals(message)).FirstOrDefaultAsync();
            return depature;
        }
    }
}
