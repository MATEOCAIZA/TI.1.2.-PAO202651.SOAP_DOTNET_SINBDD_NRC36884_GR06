using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ec.edu.monster.vista
{
    public partial class LoginForm : Form
    {
        private const string ValidUsername = "MONSTER";
        private const string ValidPassword = "MONSTER69";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.picImage = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();

            this.pnlContainer.SuspendLayout();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();

            // LoginForm (Configuración Principal)
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(44, 62, 80); // Fondo azul oscuro
            this.ClientSize = new System.Drawing.Size(980, 560);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de Unidades - Login";
            this.AcceptButton = this.btnLogin;

            // Contenedor general
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Controls.Add(this.pnlCard);

            // Tarjeta Blanca Centrada
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Size = new System.Drawing.Size(380, 460);
            this.pnlCard.Location = new System.Drawing.Point(300, 50);
            this.pnlCard.Padding = new System.Windows.Forms.Padding(30);

            // PictureBox (160x160 píxeles, como solicitaste)
            this.picImage.Size = new System.Drawing.Size(160, 160);
            this.picImage.Location = new System.Drawing.Point(110, 20);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.Image = LoadLoginImage(); // Carga la imagen jpg

            // Título
            this.lblTitle.Text = "BIENVENIDO";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(110, 185);

            // Label Usuario
            this.lblUsername.Text = "Usuario";
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUsername.ForeColor = System.Drawing.Color.Gray;
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(40, 230);

            // Textbox Usuario
            this.txtUsername.Size = new System.Drawing.Size(300, 30);
            this.txtUsername.Location = new System.Drawing.Point(40, 255);
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // Label Contraseña
            this.lblPassword.Text = "Contraseña";
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPassword.ForeColor = System.Drawing.Color.Gray;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(40, 295);

            // Textbox Contraseña
            this.txtPassword.Size = new System.Drawing.Size(300, 30);
            this.txtPassword.Location = new System.Drawing.Point(40, 320);
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.PasswordChar = '*';

            // Botón Ingresar
            this.btnLogin.Text = "INGRESAR";
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Size = new System.Drawing.Size(300, 45);
            this.btnLogin.Location = new System.Drawing.Point(40, 370);
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(41, 128, 185); // Azul
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // Label Error
            this.lblError.Size = new System.Drawing.Size(300, 35);
            this.lblError.Location = new System.Drawing.Point(40, 420);
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.ForeColor = System.Drawing.Color.Firebrick;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Agregar a la tarjeta
            this.pnlCard.Controls.Add(this.picImage);
            this.pnlCard.Controls.Add(this.lblTitle);
            this.pnlCard.Controls.Add(this.lblUsername);
            this.pnlCard.Controls.Add(this.txtUsername);
            this.pnlCard.Controls.Add(this.lblPassword);
            this.pnlCard.Controls.Add(this.txtPassword);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.lblError);

            this.Controls.Add(this.pnlContainer);

            this.pnlContainer.ResumeLayout(false);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = txtUsername.Text.Trim();
            var password = txtPassword.Text;

            if (username == ValidUsername && password == ValidPassword)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Text = "Error de credenciales. Intente de nuevo.";
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private Image LoadLoginImage()
        {
            // Busca de manera robusta la imagen "monsterLogin.jpg" en las carpetas.
            string baseDir = AppDomain.CurrentDomain.BaseDirectory ?? ".";
            string[] tryPaths = {
                "monsterLogin.jpg",
                "Content\\monsterLogin.jpg",
                "04. CLIWEB\\CLIWEB_CONUNI_SOAPDOTNET_GR01\\Content\\monsterLogin.jpg"
            };

            var dir = new DirectoryInfo(baseDir);
            for (int depth = 0; depth < 6 && dir != null; depth++)
            {
                foreach (var rel in tryPaths)
                {
                    var candidate = Path.Combine(dir.FullName, rel);
                    if (File.Exists(candidate))
                    {
                        try { return Image.FromFile(candidate); } catch { }
                    }
                }
                dir = dir.Parent;
            }
            return null;
        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnLogin;

        public System.Windows.Forms.PictureBox PictureBox => picImage;
    }
}