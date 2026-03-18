using RPM_Lab6.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RPM_Lab6.Proxy
{
    public class ImageProxy : IGraphic
    {
        private HighResImage _realImage;
        private string _filePath;

        public ImageProxy(string filePath)
        {
            _filePath = filePath;
        }

        public void Draw()
        {
            // Ленивая инициализация (Lazy Initialization)
            if (_realImage == null)
            {
                _realImage = new HighResImage(_filePath);
            }
            _realImage.Draw();
        }
    }
}
