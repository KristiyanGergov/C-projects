namespace CarDealer.Models.ViewModels.Logs
{
    using CarDealer.Models.EntityModels;
    using System;

    public class AllLogsVm
    {
        public string User { get; set; }
        public OperationLog Operation { get; set; }
        public string ModifiedTable { get; set; }
        public DateTime DateOfModifying { get; set; }
    }
}
