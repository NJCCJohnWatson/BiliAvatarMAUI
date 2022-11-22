using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiliAvatarMAUI.Services.PartialMethods
{
    public static partial class DeviceOrientationService
    {
        public static partial DeviceOrientation GetOrientation();
        public static partial void SetOrientation(DeviceOrientation orientation);

        public static partial void Init(object activity);
    }
}
