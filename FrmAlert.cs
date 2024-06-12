using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsAlert
{
    public partial class FrmAlert : Form
    {
        public FrmAlert()
        {
            InitializeComponent();
            ShowInTaskbar = false;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        public enum EnmAction
        {
            Wait,
            Start,
            Close,
            OrganizeForms
        }

        public enum EnmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private EnmAction Action;

        private int X, Y, MesageLineCount = 1;

        /// <summary>
        /// Realiza a animação de exibição e desaparecimento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (Action)
            {
                case EnmAction.Wait:
                    Timer.Interval = 5000;
                    Action = EnmAction.Close;
                    break;
                case EnmAction.Start:
                    Timer.Interval = 1;
                    Opacity += 0.1;
                    if (X < Location.X)
                    {
                        Left--;
                    }
                    else
                    {
                        if (Opacity == 1.0)
                        {
                            Action = EnmAction.Wait;
                        }
                    }
                    break;
                case EnmAction.Close:
                    Timer.Interval = 1;
                    Opacity -= 0.1;
                    Left -= 3;
                    if (Opacity == 0.0)
                    {
                        Action = EnmAction.OrganizeForms;
                        //Close();
                    }
                    break;
                case EnmAction.OrganizeForms:
                    int lastY = Y;
                    Global.allFormsOpen.Remove(Name);
                    for (int i = 1; i <= Global.allFormsOpen.Count; i++)
                    {
                        string fname = Global.allFormsOpen[i - 1];
                        FrmAlert frm = (FrmAlert)Application.OpenForms[fname];


                        if (frm != null && fname != Name)
                        {
                            lastY = (Height * i) + (i * 5);
                            frm.Location = new Point(frm.X, lastY);
                        }
                    }

                    Close();
                    break;
            }
        }

        /// <summary>
        /// Quebra as linhas de acordo com o tamanho do texto para que o alerta não fique muito largo
        /// </summary>
        /// <param name="msg">Mensagem do alerta</param>
        /// <returns></returns>
        private string BreakMessageInLines(string msg)
        {
            if (msg.Length > 60)
            {
                decimal CountLetters = (msg.Length / 3);
                string[] mensagem = msg.Split(" ");
                string novaMensagem = "", mensagemFinal = "";
                for (int i = 0; i < mensagem.Length; i++)
                {
                    novaMensagem += mensagem[i] + " ";
                    if (novaMensagem.Length > CountLetters)
                    {
                        mensagemFinal += novaMensagem + "\n";
                        novaMensagem = "";
                        MesageLineCount++;
                    }
                    else if (i == (mensagem.Length - 1))
                    {
                        mensagemFinal += novaMensagem;
                    }
                }
                return mensagemFinal;

            }
            return msg;
        }

        /// <summary>
        /// É o método que monta a o alerta e depois exibe para o usuário
        /// </summary>
        /// <param name="msg">Mensagem do alerta</param>
        /// <param name="type">Tipo do alerta, ex: Sucesso, Erro, Aviso, Informação</param>
        public void ShowAlert(string msg, EnmType type)
        {
            msg = BreakMessageInLines(msg);
            if (MesageLineCount == 1)
                LblMenssage.Location = new Point(3, 25);
            else
                LblMenssage.Location = new Point(3, 5);

            Opacity = 0.0;
            StartPosition = FormStartPosition.Manual;
            string fname;

            LblMenssage.Text = msg;
            Size = new Size(PnIcon.Width + LblMenssage.Width + PnCloseButton.Width + 15, this.Size.Height);
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            int lastNumber = Global.allFormsOpen.Count == 0 ? 1 : Convert.ToInt32(Global.allFormsOpen.Last().Replace("alert", ""));
            fname = "alert" + (lastNumber+1).ToString();
            FrmAlert frm = (FrmAlert)Application.OpenForms[fname];

            if (frm == null)
            {
                Global.allFormsOpen.Add(fname);
                Name = fname;
                X = Screen.PrimaryScreen.WorkingArea.Width - Width + 15;
                Y = (Height * Global.allFormsOpen.Count) + (Global.allFormsOpen.Count * 5);
                Location = new Point(X, Y);                
            }

            X = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

            switch (type)
            {
                case EnmType.Success:
                    Icon.IconChar = IconChar.CheckCircle;
                    BackColor = Color.SeaGreen;
                    Icon.BackColor = Color.SeaGreen;
                    break;
                case EnmType.Error:
                    Icon.IconChar = IconChar.TimesCircle;
                    BackColor = Color.DarkRed;
                    Icon.BackColor = Color.DarkRed;
                    break;
                case EnmType.Info:
                    Icon.IconChar = IconChar.InfoCircle;
                    BackColor = Color.RoyalBlue;
                    Icon.BackColor = Color.RoyalBlue;
                    break;
                case EnmType.Warning:
                    Icon.IconChar = IconChar.ExclamationCircle;
                    BackColor = Color.DarkOrange;
                    Icon.BackColor = Color.DarkOrange;
                    break;
            }

            FormsHelper.ShowTopmostNoFocus(this);
            //Show();
            Action = EnmAction.Start;
            Timer.Interval = 1;
            Timer.Start();
        }

        /// <summary>
        /// Caso o usuário feche o alerta pelo botão, ele para o Timer para iniciar novamente com o parâmetro Close
        /// </summary>
        private void BtnCloseForm_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            Action = EnmAction.Close;
            Timer.Interval = 1;
            Timer.Start();
        }

        public void Alert(string msg, EnmType type)
        {
            try
            {
                FrmAlert alertas = new();
                alertas.ShowAlert(msg, type);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar exibir a tela de alertas");
            }
        }
    }
}
