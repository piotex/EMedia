using EMediaSol.ReaderFactory;
using EMediaSol.ReaderFactory.Chunks;
using EMediaSol.RSA_algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.Forms
{
    public partial class RsaTmpForm : Form
    {
        public RsaTmpForm()
        {
            InitializeComponent();
        }

        public List<byte[]> GetChunkBytePortions(Chunk chunk)
        {
            int mod_div = ConfigClass.RsaDataPackageSize_Orig - 1;                                       //jest -1 żeby ostatni bit wynosił 0 - przez co liczba jest dodatnia
            List<byte[]> data = new List<byte[]>();

            for (int i = 0; i < chunk.Size; i++)
            {
                if (i % (mod_div) == 0)
                {
                    data.Add(new byte[ConfigClass.RsaDataPackageSize_Orig]);
                }
                data[data.Count - 1][i % mod_div] = chunk.Data[i];
            }
            return data;
        }
        public List<byte[]> GetChunkBytePortions_dec(Chunk chunk)
        {
            int mod_div = ConfigClass.RsaDataPackageSize_Enco;                      //skoro wczytujemy zaszyfrowane, to tez bierzemy bufor z zaszyfrowanych
            List<byte[]> data = new List<byte[]>();

            for (int i = 0; i < chunk.Size; i++)
            {
                if (i % (mod_div) == 0)
                {
                    data.Add(new byte[ConfigClass.RsaDataPackageSize_Enco]);
                }
                data[data.Count - 1][i % mod_div] = chunk.Data[i];
            }
            return data;
        }
        public List<byte> GetEncodedBytes(Chunk chunk)
        {
            RsaClient client = new RsaClient();
            List<byte> enc_bytes_list = new List<byte>();
            List<byte[]> data = GetChunkBytePortions(chunk);

            for (int i = 0; i < data.Count; i++)
            {
                BigInteger numb = new BigInteger(data[i]);
                var enc2 = client.Encrypt(numb);
                if (ConfigClass.IsTestVers)
                {
                    var dec2 = client.Decrypt(enc2);
                    if (dec2 != numb)
                    {
                        throw new Exception("RsaTmpForm -> Błąd w szyfrowaniu/deszyfrowaniu");
                    }
                }
                var data2 = enc2.ToByteArray();

                for (int j = 0; j < ConfigClass.RsaDataPackageSize_Enco; j++)
                {
                    byte m_byte = 0;
                    if (data2.Length > j)
                    {
                        m_byte = data2[j];
                    }
                    enc_bytes_list.Add(m_byte);
                }
            }
            return enc_bytes_list;
        }
        public List<byte> GetDecodedBytes(Chunk chunk)
        {
            RsaClient client = new RsaClient();
            List<byte> dec_bytes_list = new List<byte>();
            List<byte[]> data = GetChunkBytePortions_dec(chunk);

            for (int i = 0; i < data.Count; i++)
            {
                BigInteger numb = new BigInteger(data[i]);
                var dec2 = client.Decrypt(numb);
                var data2 = dec2.ToByteArray();

                for (int j = 0; j < ConfigClass.RsaDataPackageSize_Orig-1; j++)
                {
                    byte m_byte = 0;
                    if (data2.Length > j)
                    {
                        m_byte = data2[j];
                    }
                    dec_bytes_list.Add(m_byte);
                }
            }
            return dec_bytes_list;
        }

        private void RsaTmpForm_Load(object sender, EventArgs e)
        {
            if (ConfigClass.pathToFile == "")
            {
                MessageBox.Show("Nie podano ścierzki do pliku");
                Close();
                return;
            }
        }

        private void button_enc_Click(object sender, EventArgs e)
        {
            PNG_Model PNG_Model = new PNG_Model(ConfigClass.pathToFile);
            Chunk chunk = PNG_Model._IDAT_Chunk.ListOfIdatChuks[0];                                                  ///!!!!!!!!!!!!!! może ich być więcej - poprawić

            //chunk.CalcCRC();

            Chunk encrypted = chunk;
            List<byte> enc_bytes_list = GetEncodedBytes(chunk);
            encrypted.Size = enc_bytes_list.Count();
            encrypted.Data = enc_bytes_list.ToArray();
            //encrypted.CRC = "";                                                                   //poprawić na podstawie kodu kuby

            PNG_Model._IDAT_Chunk.ListOfIdatChuks[0] = encrypted;

            string dest_path = ConfigClass.pathToFile + "_enc.png";
            PNG_Model.SaveModel(dest_path);
            MessageBox.Show("[enc] Poprawnie zaszyfrowano plik do ścierzki: " + dest_path);
        }

        private void button_dec_Click(object sender, EventArgs e)
        {
            PNG_Model PNG_Model = new PNG_Model(ConfigClass.pathToFile);
            Chunk chunk = PNG_Model._IDAT_Chunk.ListOfIdatChuks[0];                                                  ///!!!!!!!!!!!!!! może ich być więcej - poprawić

            Chunk decrypted = chunk;
            List<byte> enc_bytes_list = GetDecodedBytes(chunk);
            decrypted.Size = enc_bytes_list.Count();
            decrypted.Data = enc_bytes_list.ToArray();
            //encrypted.CRC = "";                                                                   //poprawić na podstawie kodu kuby

            PNG_Model._IDAT_Chunk.ListOfIdatChuks[0] = decrypted;

            string dest_path = ConfigClass.pathToFile + "_dec.png";
            PNG_Model.SaveModel(dest_path);
            MessageBox.Show("[dec] Poprawnie odszyfrowano plik do ścierzki: " + dest_path);
        }
    }
}

/*
RsaNumbers.p = 2;
RsaNumbers.q = 7;
RsaNumbers.fi= 6;
RsaNumbers.n = 14;
RsaNumbers.d = 11;
RsaNumbers.e = 5;

textBox1.Text =  "p: " + RsaNumbers.p + "\r\n";
textBox1.Text += "q: " + RsaNumbers.q + "\r\n";
textBox1.Text += "fi: "+ RsaNumbers.fi +"\r\n";
textBox1.Text += "----n: " + RsaNumbers.n + "\r\n";
textBox1.Text += "----d: " + RsaNumbers.d + "\r\n";
textBox1.Text += "----e: " + RsaNumbers.e + "\r\n";
textBox1.Text += "--------------------------------------\r\n";
*/

/*
for (int i = 1; i < 10; i++)
{
    //var dec = client.Decrypt(enc);


    textBox1.Text += "i: "   + i + "\r\n";
    textBox1.Text +="enc: " + enc + "\r\n";
    textBox1.Text +="dec: " + dec + "\r\n";
    textBox1.Text +="--------------------------------------\r\n";
}
*/







//var rsa = new RSA_algo.RSA_algo();
//var prime = new PrimeNumber();
/*
textBox1.Text = "";
var tmp = new PrimeNumber().ReadRandomPrimeNumber();
textBox1.Text += tmp.ToString() + "\r\n";
*/
/*
//var tmp = rsa.GetPrimeNumber(2048);
//var tmp = prime.GenerateNBitPrimeNumber(2048);
//textBox1.Text += tmp.ToString() + "\r\n";
*/