namespace CarDealer.Services
{
    using CarDealer.Data;
    public class Service
    {
        private CarDealerContext context;
        protected Service()
        {
            this.context = new CarDealerContext();
        }
        protected CarDealerContext Context => this.context;
    }
}
