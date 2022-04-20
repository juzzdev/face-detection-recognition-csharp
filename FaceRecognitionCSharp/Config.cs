using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionCSharp
{
    public static class Config
    {
        public static string FacePhotosPath = "Source\\Faces\\";
        public static string FaceListTextFile = "Source\\FaceList.txt";
        public static string HaarCascadePath = "Resources\\haarcascade_frontalface_default.xml";
        public static int TimerResponseValue = 500;
        public static string ImageFileExtension = ".bmp";
        public static int ActiveCameraIndex = 0;//0: Default active camera device
    }
}
