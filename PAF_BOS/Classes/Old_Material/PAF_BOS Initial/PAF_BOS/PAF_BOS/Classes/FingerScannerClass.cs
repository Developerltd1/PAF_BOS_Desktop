using System;
using System.Windows.Forms;
using DPUruNet;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PAF_BOS
{
    class FingerScannerClass
    {
        /// <summary>
        /// this function converts the picture box image to an array of bytes
        /// </summary>
        /// <param name="pic"></param>
        /// <returns></returns>
        public static byte[] ConvertImageToBytArray(PictureBox pic)
        {
            byte[] byeArray;
            MemoryStream ms = new MemoryStream();
            //save the image into memory stream
            pic.Image.Save(ms, ImageFormat.Png);
            //assign the byte array with total size of memorystream
            byeArray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(byeArray, 0, byeArray.Length);
            return byeArray;
        }
        public static ReaderCollection DetactsDevices()
        {
            return ReaderCollection.GetReaders();
        }
        public static bool OpenReader(Reader currentReader)
        {
            Constants.ResultCode result = Constants.ResultCode.DP_DEVICE_FAILURE;
            result = currentReader.Open(Constants.CapturePriority.DP_PRIORITY_COOPERATIVE);
            if (result != Constants.ResultCode.DP_SUCCESS)
            {
                MessageBox.Show("Error:  " + result);
                return false;
            }
            return true;
        }
        public static bool CheckCaptureResult(CaptureResult captureResult)
        {
            if (captureResult.Data == null)
            {
                if (captureResult.ResultCode != Constants.ResultCode.DP_SUCCESS)
                {
                    throw new Exception(captureResult.ResultCode.ToString());
                }

                // Send message if quality shows fake finger
                if ((captureResult.Quality != Constants.CaptureQuality.DP_QUALITY_CANCELED))
                {
                    throw new Exception("Quality - " + captureResult.Quality);
                }
                return false;
            }

            return true;
        }
        public static bool StartCaptureAsync(Reader.CaptureCallback OnCaptured, Reader currentReader)
        {
            // Activate capture handler
            currentReader.On_Captured += new Reader.CaptureCallback(OnCaptured);

            // Call capture
            if (!CaptureFingerAsync(currentReader))
            {
                return false;
            }

            return true;
        }
        public static bool CaptureFingerAsync(Reader currentReader)
        {
            try
            {
                GetStatus(currentReader);

                Constants.ResultCode captureResult = currentReader.CaptureAsync(Constants.Formats.Fid.ANSI, Constants.CaptureProcessing.DP_IMG_PROC_DEFAULT, currentReader.Capabilities.Resolutions[0]);
                if (captureResult != Constants.ResultCode.DP_SUCCESS)
                {
                    throw new Exception("" + captureResult);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:  " + ex.Message);
                return false;
            }
        }
        public static void GetStatus(Reader currentReader)
        {
            Constants.ResultCode result = currentReader.GetStatus();

            if ((result != Constants.ResultCode.DP_SUCCESS))
            {
                throw new Exception("" + result);
            }

            if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_BUSY))
            {
                Thread.Sleep(50);
            }
            else if ((currentReader.Status.Status == Constants.ReaderStatuses.DP_STATUS_NEED_CALIBRATION))
            {
                currentReader.Calibrate();
            }
            else if ((currentReader.Status.Status != Constants.ReaderStatuses.DP_STATUS_READY))
            {
                throw new Exception("Reader Status - " + currentReader.Status.Status);
            }
        }
        public static Bitmap CreateBitmap(byte[] bytes, int width, int height)
        {
            byte[] rgbBytes = new byte[bytes.Length * 3];

            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                rgbBytes[(i * 3)] = bytes[i];
                rgbBytes[(i * 3) + 1] = bytes[i];
                rgbBytes[(i * 3) + 2] = bytes[i];
            }
            Bitmap bmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

            for (int i = 0; i <= bmp.Height - 1; i++)
            {
                IntPtr p = new IntPtr(data.Scan0.ToInt64() + data.Stride * i);
                System.Runtime.InteropServices.Marshal.Copy(rgbBytes, i * bmp.Width * 3, p, bmp.Width * 3);
            }

            bmp.UnlockBits(data);

            return bmp;
        }


        #region messages
        public enum Action
        {
            SendBitmap,
            SendMessage
        }
        #endregion 

        /// <summary>
        /// this function will exract the byte arrray from the bitmap image and that byte arrey will be used the create the fmd
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static byte[] ExtractByteArray(Bitmap img)
        {
            byte[] rawData = null;
            byte[] bitData = null;
            //ToDo: CreateFmdFromRaw only works on 8bpp bytearrays. As such if we have an image with 24bpp then average every 3 values in Bitmapdata and assign it to bitdata
            if (img.PixelFormat == PixelFormat.Format8bppIndexed)
            {

                //Lock the bitmap's bits
                BitmapData bitmapdata = img.LockBits(new System.Drawing.Rectangle(0, 0, img.Width, img.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, img.PixelFormat);
                //Declare an array to hold the bytes of bitmap
                byte[] imgData = new byte[bitmapdata.Stride * bitmapdata.Height]; //stride=360, height 392

                //Copy bitmapdata into array
                Marshal.Copy(bitmapdata.Scan0, imgData, 0, imgData.Length);//imgData.length =141120

                bitData = new byte[bitmapdata.Width * bitmapdata.Height];//ditmapdata.width =357, height = 392

                for (int y = 0; y < bitmapdata.Height; y++)
                {
                    for (int x = 0; x < bitmapdata.Width; x++)
                    {
                        bitData[bitmapdata.Width * y + x] = imgData[y * bitmapdata.Stride + x];
                    }
                }

                rawData = new byte[bitData.Length];

                for (int i = 0; i < bitData.Length; i++)
                {
                    int avg = (img.Palette.Entries[bitData[i]].R + img.Palette.Entries[bitData[i]].G + img.Palette.Entries[bitData[i]].B) / 3;
                    rawData[i] = (byte)avg;
                }
            }

            else
            {
                bitData = new byte[img.Width * img.Height];//ditmapdata.width =357, height = 392, bitdata.length=139944
                for (int y = 0; y < img.Height; y++)
                {
                    for (int x = 0; x < img.Width; x++)
                    {
                        Color pixel = img.GetPixel(x, y);
                        bitData[img.Width * y + x] = (byte)((Convert.ToInt32(pixel.R) + Convert.ToInt32(pixel.G) + Convert.ToInt32(pixel.B)) / 3);
                    }
                }

            }

            return bitData;
        }

        //SDK Function extract finger prints from finger image.
        public static DataResult<Fmd> ExtractFmdfromBmp(Bitmap img, int dpi)
        {
            byte[] imageByte = ExtractByteArray(img);
            //height, width and resolution must be same as those of image in ExtractByteArray
            DataResult<Fmd> fmd = DPUruNet.FeatureExtraction.CreateFmdFromRaw(imageByte, 0, 1, img.Width, img.Height, dpi, Constants.Formats.Fmd.ANSI);
            return fmd;
        }

        #region General Funaction
        public static byte[] ConvertImageToBytArray(Image pic)
        {
            try
            {
                byte[] byeArray;
                MemoryStream ms = new MemoryStream();
                //save the image into memory stream
                pic.Save(ms, ImageFormat.Png);
                //assign the byte array with total size of memorystream
                byeArray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(byeArray, 0, byeArray.Length);
                return byeArray;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion



    }

    public class ComparesionOfFMD
    {
        private const int PROBABILITY_ONE = 0x7fffffff;
        List<string> fmdo;
        Thread thread;
        List<int> IDs;
        public List<int> matchID;
        int fingerIndex = -1;
        //  List<Fmd> fmds = new List<Fmd>();
        Fmd fmd;
        public ComparesionOfFMD(List<string> fmdo, Fmd fmd, List<int> IDs, int fingerIndex, List<int> matchID)
        {
            this.fmdo = fmdo;
            this.fmd = fmd;
            this.IDs = IDs;
            this.matchID = matchID;
            this.fingerIndex = fingerIndex;
            thread = new Thread(new ThreadStart(run));
            thread.Start();
            thread.Join();
        }
        public void run()
        {
            int id = -1;

            foreach (string item in fmdo)
            {
                id++;
                if (item != null)
                {
                    Fmd fmd1 = Fmd.DeserializeXml(item);
                    CompareResult compareResult = Comparison.Compare(fmd, 0, fmd1, 0);
                    if (compareResult.ResultCode == Constants.ResultCode.DP_SUCCESS)
                    {
                        if (compareResult.Score >= 0 && compareResult.Score < 10000)
                        {
                            matchID.Add(IDs.ElementAt(id));
                        }
                    }
                }
            }
        }
    }
}
