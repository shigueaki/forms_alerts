namespace WinformsAlert
{
    partial class FrmAlert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            PnMessage = new Panel();
            LblMenssage = new Label();
            PnCloseButton = new Panel();
            BtnCloseForm = new FontAwesome.Sharp.IconButton();
            PnIcon = new Panel();
            Icon = new FontAwesome.Sharp.IconPictureBox();
            Timer = new System.Windows.Forms.Timer(components);
            iconButton1 = new FontAwesome.Sharp.IconButton();
            PnMessage.SuspendLayout();
            PnCloseButton.SuspendLayout();
            PnIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Icon).BeginInit();
            SuspendLayout();
            // 
            // PnMessage
            // 
            PnMessage.AutoSize = true;
            PnMessage.Controls.Add(LblMenssage);
            PnMessage.Dock = DockStyle.Fill;
            PnMessage.Location = new Point(61, 0);
            PnMessage.Name = "PnMessage";
            PnMessage.Size = new Size(110, 77);
            PnMessage.TabIndex = 16;
            // 
            // LblMenssage
            // 
            LblMenssage.AutoSize = true;
            LblMenssage.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            LblMenssage.ForeColor = Color.White;
            LblMenssage.Location = new Point(3, 11);
            LblMenssage.Name = "LblMenssage";
            LblMenssage.Size = new Size(100, 16);
            LblMenssage.TabIndex = 10;
            LblMenssage.Text = "LblMenssage";
            // 
            // PnCloseButton
            // 
            PnCloseButton.Controls.Add(iconButton1);
            PnCloseButton.Controls.Add(BtnCloseForm);
            PnCloseButton.Dock = DockStyle.Right;
            PnCloseButton.Location = new Point(171, 0);
            PnCloseButton.Name = "PnCloseButton";
            PnCloseButton.Size = new Size(28, 77);
            PnCloseButton.TabIndex = 15;
            // 
            // BtnCloseForm
            // 
            BtnCloseForm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BtnCloseForm.FlatAppearance.BorderSize = 0;
            BtnCloseForm.FlatStyle = FlatStyle.Flat;
            BtnCloseForm.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            BtnCloseForm.IconColor = Color.Gainsboro;
            BtnCloseForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCloseForm.IconSize = 20;
            BtnCloseForm.Location = new Point(-170, 2);
            BtnCloseForm.Name = "BtnCloseForm";
            BtnCloseForm.Size = new Size(24, 19);
            BtnCloseForm.TabIndex = 11;
            BtnCloseForm.UseVisualStyleBackColor = true;
            // 
            // PnIcon
            // 
            PnIcon.Controls.Add(Icon);
            PnIcon.Dock = DockStyle.Left;
            PnIcon.Location = new Point(0, 0);
            PnIcon.Name = "PnIcon";
            PnIcon.Size = new Size(61, 77);
            PnIcon.TabIndex = 14;
            // 
            // Icon
            // 
            Icon.BackColor = SystemColors.Highlight;
            Icon.IconChar = FontAwesome.Sharp.IconChar.InfoCircle;
            Icon.IconColor = Color.White;
            Icon.IconFont = FontAwesome.Sharp.IconFont.Solid;
            Icon.IconSize = 59;
            Icon.Location = new Point(1, 11);
            Icon.Name = "Icon";
            Icon.Size = new Size(59, 59);
            Icon.SizeMode = PictureBoxSizeMode.StretchImage;
            Icon.TabIndex = 2;
            Icon.TabStop = false;
            // 
            // Timer
            // 
            Timer.Tick += Timer_Tick;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.XmarkCircle;
            iconButton1.IconColor = Color.Gainsboro;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 20;
            iconButton1.Location = new Point(1, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(24, 19);
            iconButton1.TabIndex = 12;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += BtnCloseForm_Click;
            // 
            // FrmAlert
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Highlight;
            ClientSize = new Size(199, 77);
            Controls.Add(PnMessage);
            Controls.Add(PnCloseButton);
            Controls.Add(PnIcon);
            Font = new Font("Arial Narrow", 12F, FontStyle.Bold);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmAlert";
            ShowInTaskbar = false;
            Text = "Alerta";
            PnMessage.ResumeLayout(false);
            PnMessage.PerformLayout();
            PnCloseButton.ResumeLayout(false);
            PnIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel PnMessage;
        private Label LblMenssage;
        private Panel PnCloseButton;
        private FontAwesome.Sharp.IconButton BtnCloseForm;
        private Panel PnIcon;
        private FontAwesome.Sharp.IconPictureBox Icon;
        private System.Windows.Forms.Timer Timer;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}