using System;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using System.ComponentModel;
using System.Timers;
using System.Runtime.CompilerServices;
using Emgu.CV.Face;
using Emgu.CV.Util;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace FaceRecognitionCSharp
{
    public partial class Form1 : Form
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        private VideoCapture videoCapture;
        private CascadeClassifier haarCascade;
        private Image<Bgr, Byte> bgrFrame = null;
        private Image<Gray, Byte> detectedFace = null;
        private List<FaceData> faceList = new List<FaceData>();
        private VectorOfMat imageList = new VectorOfMat();
        private List<string> nameList = new List<string>();
        private VectorOfInt labelList = new VectorOfInt();

        private EigenFaceRecognizer recognizer;
        private System.Timers.Timer captureTimer;
        #region FaceName
        private string faceName;
        public string FaceName
        {
            get { return faceName; }
            set
            {
                faceName = value.ToUpper();
                lblFaceName.Invoke(new Action(() => { lblFaceName.Text = faceName; }));
                NotifyPropertyChanged();
            }
        }
        #endregion
        #region CameraCaptureImage
        private Bitmap cameraCapture;
        public Bitmap CameraCapture
        {
            get { return cameraCapture; }
            set
            {
                cameraCapture = value;
                imgCamera.Invoke(new Action(() => { imgCamera.Image = BitmapFromSource(BitmapToImageSource(cameraCapture)); }));
                //imgCamera.Image = BitmapFromSource(BitmapToImageSource(cameraCapture));
                NotifyPropertyChanged();
            }
        }
        #endregion
        #region CameraCaptureFaceImage
        private Bitmap cameraCaptureFace;
        public Bitmap CameraCaptureFace
        {
            get { return cameraCaptureFace; }
            set
            {
                cameraCaptureFace = value;
                imgDetectFace.Invoke(new Action(() => { imgDetectFace.Image = BitmapFromSource(BitmapToImageSource(cameraCaptureFace)); }));
                //imgCamera.Image = BitmapFromSource(BitmapToImageSource(cameraCaptureFace));
                NotifyPropertyChanged();
            }
        }
        #endregion
        #endregion

        #region Event
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private void CaptureTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (videoCapture != null)
            {
                ProcessFrame();
            }
        }
        #endregion

        #region Method
        public void GetFacesList()
        {
            //haar cascade classifier
            if (!File.Exists(Config.HaarCascadePath))
            {
                string text = "Cannot find Haar cascade data file:\n\n";
                text += Config.HaarCascadePath;
                DialogResult result = MessageBox.Show(text, "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            haarCascade = new CascadeClassifier(Config.HaarCascadePath);
            faceList.Clear();
            string line;
            FaceData faceInstance = null;

            // Create empty directory / file for face data if it doesn't exist
            if (!Directory.Exists(Config.FacePhotosPath))
            {
                Directory.CreateDirectory(Config.FacePhotosPath);
            }

            if (!File.Exists(Config.FaceListTextFile))
            {
                string text = "Cannot find face data file:\n\n";
                text += Config.FaceListTextFile + "\n\n";
                text += "If this is your first time running the app, an empty file will be created for you.";
                DialogResult result = MessageBox.Show(text, "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.OK:
                        String dirName = Path.GetDirectoryName(Config.FaceListTextFile);
                        Directory.CreateDirectory(dirName);
                        File.Create(Config.FaceListTextFile).Close();
                        break;
                }
            }

            StreamReader reader = new StreamReader(Config.FaceListTextFile);
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineParts = line.Split(':');
                faceInstance = new FaceData();
                faceInstance.FaceImage = new Image<Gray, byte>(Config.FacePhotosPath + lineParts[0] + Config.ImageFileExtension);
                faceInstance.PersonName = lineParts[1];
                faceList.Add(faceInstance);
            }
            foreach (var face in faceList)
            {
                imageList.Push(face.FaceImage.Mat);
                nameList.Add(face.PersonName);
                labelList.Push(new[] { i++ });
            }
            reader.Close();

            // Train recogniser
            if (imageList.Size > 0)
            {
                recognizer = new EigenFaceRecognizer(imageList.Size);
                recognizer.Train(imageList, labelList);
            }

        }

        private void ProcessFrame()
        {
            bgrFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>();

            if (bgrFrame != null)
            {
                try
                {//for emgu cv bug
                    Image<Gray, byte> grayframe = bgrFrame.Convert<Gray, byte>();

                    Rectangle[] faces = haarCascade.DetectMultiScale(grayframe, 1.2, 10, new System.Drawing.Size(50, 50), new System.Drawing.Size(200, 200));

                    //detect face
                    FaceName = "No face detected";
                    foreach (var face in faces)
                    {
                        bgrFrame.Draw(face, new Bgr(255, 255, 0), 2);
                        detectedFace = bgrFrame.Copy(face).Convert<Gray, byte>();
                        FaceRecognition();
                        break;
                    }
                    CameraCapture = bgrFrame.ToBitmap();
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    //todo log
                }

            }
        }


        private void FaceRecognition()
        {
            if (imageList.Size != 0)
            {
                //Eigen Face Algorithm
                FaceRecognizer.PredictionResult result = recognizer.Predict(detectedFace.Resize(100, 100, Inter.Cubic));
                FaceName = nameList[result.Label];
                CameraCaptureFace = detectedFace.ToBitmap();
            }
            else
            {
                FaceName = "Please Add Face";
            }
        }
        /// <summary>
        /// Convert bitmap to bitmap image for image control
        /// </summary>
        /// <param name="bitmap">Bitmap image</param>
        /// <returns>Image Source</returns>
        private BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }

        private System.Drawing.Bitmap BitmapFromSource(BitmapSource bitmapsource)
        {
            System.Drawing.Bitmap bitmap;
            using (MemoryStream outStream = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder();
                enc.Frames.Add(BitmapFrame.Create(bitmapsource));
                enc.Save(outStream);
                bitmap = new System.Drawing.Bitmap(outStream);
            }
            return bitmap;
        }

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
