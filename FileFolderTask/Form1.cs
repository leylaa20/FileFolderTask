namespace FileFolderTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Open_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Clear();

                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                string[] directories = Directory.GetDirectories(folderBrowserDialog1.SelectedPath);

                foreach (string file in files)
                    listBox1.Items.Add(file);

                foreach (string directory in directories)
                    listBox1.Items.Add(directory);
            }

            DirectoryInfo folder = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

            lbl_bytes.Text = FolderSize(folder).ToString();
            lbl_mb.Text = (FolderSize(folder) * 0.000001).ToString();
            lbl_gb.Text = (FolderSize(folder) * 0.000000001).ToString();
        }

        static long FolderSize(DirectoryInfo folder)
        {
            long size = 0;

            FileInfo[] files = folder.GetFiles();
            DirectoryInfo[] subFolders = folder.GetDirectories();

            foreach (FileInfo file in files)
                size += file.Length;

            foreach (DirectoryInfo directory in subFolders)
                size += FolderSize(directory);

            return size;
        }
    }
}