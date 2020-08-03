using MetroFramework.Forms;
using MetroFramework;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;

namespace WindowsFormsApp26
{
    public partial class Form1 : MetroForm
    {
        System.DateTime dates = new System.DateTime();
        static Mutex mutexObj = new Mutex();

        private int data;
        System.Windows.Forms.OpenFileDialog openFile ;
       
        public Form1()
        {
            InitializeComponent();
            
            openFile = new System.Windows.Forms.OpenFileDialog();
        }

        private void File_Click(object sender, System.EventArgs e)
        {
            try
            {
                openFile.FileName= metroTextBox1.Text;
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                     metroTextBox1.Text= openFile.FileName;


                }
            }
            finally {
            }
        }


        async public void  Encrypt()
        {
            mutexObj.WaitOne();


            await Task.Run(()=> EncryptFile(openFile.FileName, "Encrypt.txt"));
            mutexObj.ReleaseMutex();


        }
        async public void Decryp()
        {
            mutexObj.WaitOne();


            await Task.Run(() => DecryptFile(openFile.FileName, "Decryp.txt"));

            mutexObj.ReleaseMutex();


        }

        private void EncryptFile(string inputFile, string outputFile)
        {


            try
            {
                string password = metroTextBox2.Text; 
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);




                while ((data = fsIn.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);


                }


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                MetroMessageBox.Show(this,"Encryption failed!", "Error");
            }

        }

        private void DecryptFile(string inputFile, string outputFile)
        {

            mutexObj.WaitOne();

            string password = metroTextBox2.Text; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            mutexObj.ReleaseMutex();

        }

        private void metroButton3_Click(object sender, System.EventArgs e)
        {
            if (metroTextBox2.Text.Length >= 8 && metroTextBox2.Text.Length <= 8)
            {

                if ( radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;
                    Decryp();



                }
                else if (radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;

                    Encrypt();


                }
            }
            else
            {

                MetroMessageBox.Show(this,"Error");

            }
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {try
            {

                if (radioButton2.Checked == true)
                {
                    radioButton1.Checked = false;


                    System.IO.File.WriteAllText("Encrypt.txt", "");
                }
                else if (radioButton1.Checked == true)
                {
                    radioButton2.Checked = false;
                    System.IO.File.WriteAllText("Decryp.txt", "");



                }

            }
            finally
            {



            }




            }

       

        private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;


            }
        }

        private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
        {

            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;

            }
        }
    }
}
