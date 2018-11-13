using System.Collections.Generic;

namespace MoleculeTable.Models
{
    public class Molecule
    {
        public string compoundName { get; set; }
        public List<Atom> atoms { get; set; }
    }
}