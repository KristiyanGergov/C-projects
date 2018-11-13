using BazarCamera.Domain.Entity;
using BazarCamera.Domain.View;
using System.Collections.Generic;

namespace BazarCamera.Repository.Abstract
{
    public interface ICameraRepository
    {
        IEnumerable<Camera> Cameras { get; }
        CameraVm CameraDetails(int id);
        void AddCamera(CameraVm vm);
        Camera Search(string camera);
    }
}
