using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.Fourier
{
    public partial class FourierTransform_Form : Form
    {
        public static PictureBox PitureBox_ImageM;
        public static PictureBox FourierPhaseM;
        public static PictureBox FourierMagM;
        public FourierTransform_Form()
        {
            InitializeComponent();

            FourierMagM = FourierMag;
            FourierPhaseM = FourierPhase;
            PitureBox_ImageM = pictureBox_Image;
        }

        private void FourierTransform_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
