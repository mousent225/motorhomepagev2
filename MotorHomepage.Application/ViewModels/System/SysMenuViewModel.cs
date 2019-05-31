using MotorHomepage.Data.Enums;

namespace MotorHomepage.Application.ViewModels.System
{
    public class SysMenuViewModel
    {
        public string Id { get; set; }
        public string Name { set; get; }

        public string URL { set; get; }


        public string ParentId { set; get; }

        public string IconCss { get; set; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}
