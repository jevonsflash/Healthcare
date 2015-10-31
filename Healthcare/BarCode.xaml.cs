﻿using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.oned;
using com.google.zxing.qrcode;
using com.google.zxing.common;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Collections.Generic;
using Microsoft.Phone.Shell;

namespace WP7BarcodeScannerExample
{
    public partial class BarCode : PhoneApplicationPage
    {
        private PhotoCamera _photoCamera;
        private PhotoCameraLuminanceSource _luminance;
        private readonly DispatcherTimer _timer;
        private Reader _reader = null;

        public BarCode()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (o, arg) => ScanPreviewBuffer();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (Microsoft.Devices.Environment.DeviceType == Microsoft.Devices.DeviceType.Emulator)
            {
                MessageBox.Show("You must deploy this sample to a device, instead of the emulator so that you can get a video stream including a barcode/QR code");
                this.IsEnabled = false;
                base.NavigationService.GoBack();
            }
            else
            {
                string type = "";
                if (NavigationContext.QueryString.TryGetValue("type", out type) && type == "qrcode")
                {
                    _reader = new QRCodeReader();
                }
                else
                {
                    _reader = new EAN13Reader();
                }

                _photoCamera = new PhotoCamera();
                _photoCamera.Initialized += new EventHandler<CameraOperationCompletedEventArgs>(cam_Initialized);
                _videoBrush.SetSource(_photoCamera);
                BarCodeRectInitial();
                base.OnNavigatedTo(e);
            }
        }
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if ((Application.Current.RootVisual as PhoneApplicationFrame) != null)
            {
                (Application.Current.RootVisual as PhoneApplicationFrame).RemoveBackEntry();
            }

            if (_photoCamera != null)
            {
                _timer.Stop();
                _photoCamera.CancelFocus();
                _photoCamera.Dispose();
            }
        }

        void cam_Initialized(object sender, CameraOperationCompletedEventArgs e)
        {
            //int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            //int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
            int width = 640;
            int height = 480;
            _luminance = new PhotoCameraLuminanceSource(width, height);

            Dispatcher.BeginInvoke(() =>
            {
                _previewTransform.Rotation = _photoCamera.Orientation;
                _timer.Start();
            });
            _photoCamera.FlashMode = FlashMode.Auto;
            _photoCamera.Focus();
        }

        public void SetStillPicture()
        {
            int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
            int[] PreviewBuffer = new int[width * height];
            _photoCamera.GetPreviewBufferArgb32(PreviewBuffer);

            WriteableBitmap wb = new WriteableBitmap(width, height);
            PreviewBuffer.CopyTo(wb.Pixels, 0);

            MemoryStream ms = new MemoryStream();
            wb.SaveJpeg(ms, wb.PixelWidth, wb.PixelHeight, 0, 80);
            ms.Seek(0, SeekOrigin.Begin);

            BitmapImage bi = new BitmapImage();
            bi.SetSource(ms);
            ImageBrush still = new ImageBrush();
            still.ImageSource = bi;
            frame.Fill = still;
            still.RelativeTransform = new CompositeTransform()
            { CenterX = 0.5, CenterY = 0.5, Rotation = _photoCamera.Orientation };
        }

        private void ScanPreviewBuffer()
        {
            try
            {
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                Result result = _reader.decode(binBitmap);
                if (result != null)
                {
                    _timer.Stop();
                    SetStillPicture();
                    BarCodeRectSuccess();
                    Dispatcher.BeginInvoke(() =>
                    {
                        string destination = "/DrugResultPage.xaml";
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        dic.Add("code", result.Text);
                        PhoneApplicationService.Current.State["dic"] = dic;
                        destination += string.Format("?type={0}", "DrugCode");

                        //读取成功，结果存放在result.Text
                        NavigationService.Navigate(new Uri(destination, UriKind.Relative));

                    });
                }
                else
                {
                    _photoCamera.Focus();
                }
            }
            catch
            {
            }
        }

        void BarCodeRectSuccess()
        {
            Dispatcher.BeginInvoke(() =>
            {
                _marker1.Fill = new SolidColorBrush(Colors.Green);
                _marker2.Fill = new SolidColorBrush(Colors.Green);
                _marker3.Fill = new SolidColorBrush(Colors.Green);
                _marker4.Fill = new SolidColorBrush(Colors.Green);
                _marker5.Fill = new SolidColorBrush(Colors.Green);
                _marker6.Fill = new SolidColorBrush(Colors.Green);
                _marker7.Fill = new SolidColorBrush(Colors.Green);
                _marker8.Fill = new SolidColorBrush(Colors.Green);
            });
        }

        void BarCodeRectInitial()
        {
            _marker1.Fill = new SolidColorBrush(Colors.Red);
            _marker2.Fill = new SolidColorBrush(Colors.Red);
            _marker3.Fill = new SolidColorBrush(Colors.Red);
            _marker4.Fill = new SolidColorBrush(Colors.Red);
            _marker5.Fill = new SolidColorBrush(Colors.Red);
            _marker6.Fill = new SolidColorBrush(Colors.Red);
            _marker7.Fill = new SolidColorBrush(Colors.Red);
            _marker8.Fill = new SolidColorBrush(Colors.Red);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _photoCamera.Focus();
        }
    }
}