using MotorHomepage.Data.Entities;
using MotorHomepage.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MotorHomepage.Data.EF.Repositories
{
    public class SysMenuRepository : EFRepository<SysMenu, string>, ISysMenuRepository
    {
        public SysMenuRepository(AppDbContext context) : base(context)
        {
        }
    }
}
