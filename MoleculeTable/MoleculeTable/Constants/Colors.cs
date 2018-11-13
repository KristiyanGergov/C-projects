using System.Collections.Generic;
using System.Drawing;

namespace MoleculeTable.Constants
{
    public class Colors
    {
        public Dictionary<string, Color> C = new Dictionary<string, Color>();
        public Color AlkaliMetal = Color.FromArgb(255, 99, 65);
        public Color Alkaline = Color.FromArgb(255, 169, 0);
        public Color Transition = Color.FromArgb(255, 206, 0);
        public Color Metalloid = Color.FromArgb(60, 235, 199);
        public Color Diatomic = Color.FromArgb(80, 255, 41);
        public Color Polyatomic = Color.FromArgb(85, 227, 52);
        public Color PostTransition = Color.FromArgb(225, 237, 57);
        public Color NobleGas = Color.FromArgb(31, 138, 254);
        public Color Actinide = Color.FromArgb(199, 141, 255);
        public Color Lanthanide = Color.FromArgb(255, 158, 255);

        public Colors()
        {
            C.Add("alkali", AlkaliMetal);
            C.Add("alkaline", Alkaline);
            C.Add("transition", Transition);
            C.Add("metalloid", Metalloid);
            C.Add("diatomic", Diatomic);
            C.Add("polyatomic", Polyatomic);
            C.Add("post-transition", PostTransition);
            C.Add("noble", NobleGas);
            C.Add("actinide", Actinide);
            C.Add("lanthanide", Lanthanide);
        }
    }
}