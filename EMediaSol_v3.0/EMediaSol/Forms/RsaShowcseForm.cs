using EMediaSol.ReaderFactory;
using EMediaSol.RSA_algo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EMediaSol.Forms
{
    public partial class RsaShowcseForm : Form
    {
        public RsaShowcseForm()
        {
            InitializeComponent();
        }

        private void RsaShowcseForm_Load(object sender, EventArgs e)
        {
            rsa_img_enc_my();
        }


        public void rsa_img_enc()
        {
            if (ConfigClass.pathToFile == "")
            {
                MessageBox.Show("Nie wygrano pliku png");
                Close();
            }
            RsaTmpForm ttt = new RsaTmpForm();

            Bitmap bmp = new Bitmap(ConfigClass.pathToFile);
            byte[] pixels = new byte[bmp.Width * bmp.Height * 3];
            ulong counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    byte r = bmp.GetPixel(i, j).R;
                    byte g = bmp.GetPixel(i, j).G;
                    byte b = bmp.GetPixel(i, j).B;

                    pixels[counter] = r;
                    counter++;
                    pixels[counter] = g;
                    counter++;
                    pixels[counter] = b;
                    counter++;
                }
            }

            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            byte[] dataToEncrypt = pixels;
            byte[] encryptedData = new byte[bmp.Width*bmp.Height*3*2];
            byte[] decryptedData;

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                //decryptedData = RSADecrypt(encryptedData, RSA.ExportParameters(true), false);
                //Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
            }

            int scale = 1;// ConfigClass.RsaDataPackageSize_Enco / ConfigClass.RsaDataPackageSize_Orig;
            Bitmap rsa_bitmap = new Bitmap(bmp, new Size(bmp.Width * scale, bmp.Height * scale));
            counter = 0;

            for (int i = 0; i < bmp.Width * scale; i++)
            {
                for (int j = 0; j < bmp.Height * scale; j++)
                {
                    try
                    {
                        int r = encryptedData[counter];
                        counter++;
                        int g = encryptedData[counter];
                        counter++;
                        int b = encryptedData[counter];
                        counter++;
                        rsa_bitmap.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            pictureBox1.Image = rsa_bitmap;
            pictureBox1.Width = rsa_bitmap.Width;
            pictureBox1.Height = rsa_bitmap.Height;


        }

        public static byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            catch (CryptographicException e)
            {
                //Console.WriteLine(e.Message);
                return null;
            }
        }

        public static byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSAKeyInfo);
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            catch (CryptographicException e)
            {
                //Console.WriteLine(e.ToString());
                return null;
            }
        }
        public void rsa_img_enc_my()
        {
            if (ConfigClass.pathToFile == "")
            {
                MessageBox.Show("Nie wygrano pliku png");
                Close();
            }
            RsaTmpForm ttt = new RsaTmpForm();

            Bitmap bmp = new Bitmap(ConfigClass.pathToFile);
            byte[] pixels = new byte[bmp.Width*bmp.Height*3];
            ulong counter = 0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    byte r = bmp.GetPixel(i, j).R;
                    byte g = bmp.GetPixel(i, j).G;
                    byte b = bmp.GetPixel(i, j).B;

                    pixels[counter] = r;
                    counter++;
                    pixels[counter] = g;
                    counter++;
                    pixels[counter] = b;
                    counter++;
                }
            }


            pictureBox1.Image = bmp;
            pictureBox1.Size = bmp.Size;


            Chunk chunk = new Chunk();
            chunk.Size = pixels.Length;
            chunk.Data = pixels;

            Chunk encrypted = chunk;
            List<byte> enc_bytes_list = ttt.GetEncodedBytes(chunk);
            encrypted.Size = enc_bytes_list.Count();
            encrypted.Data = enc_bytes_list.ToArray();

            int scale = 1;// ConfigClass.RsaDataPackageSize_Enco / ConfigClass.RsaDataPackageSize_Orig;
            Bitmap rsa_bitmap = new Bitmap(bmp, new Size(bmp.Width * scale, bmp.Height * scale));
            counter = 0;

            for (int i = 0; i < bmp.Width*scale; i++)
            {
                for (int j = 0; j < bmp.Height*scale; j++)
                {
                    try
                    {
                        int r = encrypted.Data[counter];
                        counter++;
                        int g = encrypted.Data[counter];
                        counter++;
                        int b = encrypted.Data[counter];
                        counter++;
                        rsa_bitmap.SetPixel(i, j, Color.FromArgb(255, r, g, b));
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            pictureBox1.Image = rsa_bitmap;
            pictureBox1.Width = rsa_bitmap.Width;
            pictureBox1.Height= rsa_bitmap.Height;








        }
    }
}
