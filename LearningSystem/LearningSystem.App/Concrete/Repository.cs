namespace LearningSystem.App.Concrete
{
    public class Repository
    {
        private LearningSystemContext context;
        protected Repository()
        {
            this.context = new LearningSystemContext();
        }
        protected LearningSystemContext Context => this.context;
    }
}