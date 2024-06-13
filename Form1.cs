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

            Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem VERMELHA - {counter++}", FrmAlert.EnmType.Error));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem VERDE - {counter++}", FrmAlert.EnmType.Success));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem AZUL - {counter++}", FrmAlert.EnmType.Info));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Global.allNotifications.Add(new Tuple<string, FrmAlert.EnmType>($"Mensagem LARANJA - {counter++}", FrmAlert.EnmType.Warning));
        }
    }
}
