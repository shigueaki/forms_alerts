namespace WinformsAlert
{
    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();
        }
        int counter = 1;
        private void button1_Click(object sender, EventArgs e)
        {

            Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem VERMELHA sendo exibida - {counter++}", FrmAlert.EnmType.Error));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
                Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem VERDE sendo exibida - {counter++}", FrmAlert.EnmType.Success));            
        }
    }
}
