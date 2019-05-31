using MotorHomepage.Application.ViewModels.System;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MotorHomepage.Application.Interfaces
{
    public interface ISysMenuService : IDisposable
    {
        Task<List<SysMenuViewModel>> GetAll();
        List<SysMenuViewModel> GetAllByPermission(Guid userId);
    }
}
