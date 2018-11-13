using Bazar.Camera.Repository.Abstract;
using BazarCamera.Data;
using BazarCamera.Domain;
using System.Collections.Generic;

namespace Bazar.Camera.Repository
{
    public class CameraRepository : ICameraRepository
    {
        private BazarCameraContext context = new BazarCameraContext();
        
        //public IEnumerable<Camera> Cameras { get {return this.context.Cameras} }
    }
}
