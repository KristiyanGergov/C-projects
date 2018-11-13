using comboboxTest.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;

namespace comboboxTest.Utility
{

    public class MoleculeUtility
    {
        private List<Molecule> molecules = new List<Molecule>();
        public List<Molecule> GetCars(DataGridView dataGridView)
        {
            List<Molecule> molecules = new List<Molecule>();
            foreach (DataGridViewRow Datarow in dataGridView.Rows)
            {
                if (Datarow.Cells[1].Value == null)
                    break;
                var color = Datarow.Cells["Color"].Value?.ToString();
                var make = Datarow.Cells["Make"].Value?.ToString();
                var model = Datarow.Cells["Model"].Value?.ToString();
                var mass = decimal.Parse(Datarow.Cells["Mass"].Value.ToString());
                var size = decimal.Parse(Datarow.Cells["Size"].Value.ToString());
                var linkIndex = int.Parse(Datarow.Cells["LinkIndex"].Value.ToString());
                var linkConnectionNumber = int.Parse(Datarow.Cells["LinkConnectionNumber"].Value.ToString());
                Molecule molecule = new Molecule(mass, size, linkIndex, linkConnectionNumber);
                molecules.Add(molecule);
            }
            this.molecules = molecules;
            return molecules;
        }
        public string GetJson(DataGridView dataGridView)
        {
            string json = JsonConvert.SerializeObject(GetCars(dataGridView));
            return json;
        }
    }
}
