namespace MoleculeTable.Models
{
    public class Atom
    {
        public Atom(string name, decimal mass, decimal size, string category, string color)
        {
            this.name = name;
            this.mass = mass;
            this.size = size;
            this.category = category;
            this.linkIndex = linkIndex;
            this.linkConnectionNum = linkConnectionNum;
            this.viewOrder = viewOrder;
            this.color = color;
        }

        public string color { get; set; }
        public string category { get; set; }
        public string name { get; set; }
        public int viewOrder { get; set; }
        public decimal mass { get; set; }
        public decimal size { get; set; }
        public int? linkIndex { get; set; }
        public int linkConnectionNum { get; set; }
    }
}