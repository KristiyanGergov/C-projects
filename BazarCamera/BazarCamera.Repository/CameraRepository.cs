using System.Collections.Generic;
using BazarCamera.Repository.Abstract;
using BazarCamera.Data;
using BazarCamera.Domain.Entity;
using BazarCamera.Domain.View;
using AutoMapper;

namespace BazarCamera.Repository
{
    public class CameraRepository : ICameraRepository
    {
        private BazarCameraContext context = new BazarCameraContext();
        public IEnumerable<Camera> Cameras
        {
            get { return this.context.Cameras; }
        }
        public CameraVm CameraDetails(int id)
        {
            Camera camera = this.context.Cameras.Find(id);
            CameraVm vm =
                Mapper.Instance.Map<Camera, CameraVm>(camera);
            return vm;

        }
        public void AddCamera(CameraVm vm)
        {
            Camera camera = Mapper.Instance.Map<CameraVm, Camera>(vm);
            this.context.Cameras.Add(camera);
            this.context.SaveChanges();
        }
        //public CameraVm EditCamera(int id)
        //{
        //    Camera camera = this.context.Cameras.Find(id);

            
        //}
        public Camera Search(string camera)
        {
            foreach (var item in this.context.Cameras)
            {
                string fullName = item.Model + " " + item.Make;
                if (fullName.Contains(camera))
                {
                    return item;
                }
            }
            return null;
        }
    }
}