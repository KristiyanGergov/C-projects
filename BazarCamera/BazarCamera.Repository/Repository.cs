using BazarCamera.Data;

namespace BazarCamera.Repository
{
    public class Repository
    {
        private BazarCameraContext context;
        protected Repository()
        {
            this.context = new BazarCameraContext();
        }
        protected BazarCameraContext Context => this.context;
    }
}