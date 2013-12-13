using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using monopoly.prototypeV2.logic.classes;

namespace monopoly.prototypeV2.client.interfaces
{
    interface IctrlSquare
    {
        String ctrlTopName { get; set; }

        String ctrlBackColor { get; set; }

        String ctrlTopColor { get; set; }

        String ctrlBottomName { get; set; }

        void addAvatar(PictureBox PBavatar, cAvatar oAvatar);

        void clearAvatars();

        System.Windows.Forms.Orientation orientation { get; set; }

    }
}
