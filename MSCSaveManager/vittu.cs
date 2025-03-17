using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSCSaveManager
{
    public partial class vittu : Form
    {
        public vittu()
        {
            InitializeComponent();
        }

        private void vittu_Load(object sender, EventArgs e)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "vittu.mp4");
            File.WriteAllBytes(tempFilePath, Properties.Resources.vittu);
            axWindowsMediaPlayer1.URL = tempFilePath;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
