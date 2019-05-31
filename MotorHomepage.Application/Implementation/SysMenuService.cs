using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MotorHomepage.Application.Interfaces;
using MotorHomepage.Application.ViewModels.System;
using MotorHomepage.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorHomepage.Application.Implementation
{
    public class SysMenuService : ISysMenuService
    {
        ISysMenuRepository _sysMenuRepository;
        public SysMenuService(ISysMenuRepository sysMenuRepository)
        {
            _sysMenuRepository = sysMenuRepository;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<List<SysMenuViewModel>> GetAll()
        {
            return _sysMenuRepository.FindAll().ProjectTo<SysMenuViewModel>().ToListAsync();
            
        }

        public List<SysMenuViewModel> GetAllByPermission(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
