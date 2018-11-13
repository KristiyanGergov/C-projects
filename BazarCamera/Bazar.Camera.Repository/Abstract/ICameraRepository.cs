using System.Collections.Generic;
using BazarCamera.Domain;

namespace Bazar.Camera.Repository.Abstract
{
    public interface ICameraRepository
    {
        IEnumerable<Camera> Cameras { get; }
    }
}
