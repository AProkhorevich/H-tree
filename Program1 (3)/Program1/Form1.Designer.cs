using System.Windows.Forms;

namespace Program1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cnt_steps_box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_do_steps = new System.Windows.Forms.Button();
            this.error_label = new System.Windows.Forms.Label();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.save_button = new System.Windows.Forms.Button();
            this.reduction_ratio_box = new System.Windows.Forms.TextBox();
            this.reduction_ratio_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cnt_steps_box
            // 
            this.cnt_steps_box.Location = new System.Drawing.Point(11, 123);
            this.cnt_steps_box.Name = "cnt_steps_box";
            this.cnt_steps_box.Size = new System.Drawing.Size(96, 20);
            this.cnt_steps_box.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Количество шагов";
            // 
            // button_do_steps
            // 
            this.button_do_steps.BackColor = System.Drawing.Color.White;
            this.button_do_steps.Location = new System.Drawing.Point(10, 267);
            this.button_do_steps.Name = "button_do_steps";
            this.button_do_steps.Size = new System.Drawing.Size(95, 48);
            this.button_do_steps.TabIndex = 4;
            this.button_do_steps.Text = "Построить";
            this.button_do_steps.UseVisualStyleBackColor = false;
            this.button_do_steps.Click += new System.EventHandler(this.button_do_steps_Click);
            // 
            // error_label
            // 
            this.error_label.AutoSize = true;
            this.error_label.BackColor = System.Drawing.Color.White;
            this.error_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.error_label.ForeColor = System.Drawing.Color.Red;
            this.error_label.Location = new System.Drawing.Point(11, 239);
            this.error_label.Name = "error_label";
            this.error_label.Size = new System.Drawing.Size(126, 13);
            this.error_label.TabIndex = 7;
            this.error_label.Text = "заполните число шагов";
            this.error_label.Visible = false;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(373, 44);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(510, 546);
            this.zedGraphControl1.TabIndex = 8;
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(110, 267);
            this.save_button.Margin = new System.Windows.Forms.Padding(2);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(95, 48);
            this.save_button.TabIndex = 47;
            this.save_button.Text = "Сохранить";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // reduction_ratio_box
            // 
            this.reduction_ratio_box.Location = new System.Drawing.Point(11, 73);
            this.reduction_ratio_box.Name = "reduction_ratio_box";
            this.reduction_ratio_box.Size = new System.Drawing.Size(95, 20);
            this.reduction_ratio_box.TabIndex = 48;
            // 
            // reduction_ratio_label
            // 
            this.reduction_ratio_label.AutoSize = true;
            this.reduction_ratio_label.Location = new System.Drawing.Point(11, 54);
            this.reduction_ratio_label.Name = "reduction_ratio_label";
            this.reduction_ratio_label.Size = new System.Drawing.Size(142, 13);
            this.reduction_ratio_label.TabIndex = 49;
            this.reduction_ratio_label.Text = "коэффициент уменьшения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 50;
            this.label1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(909, 625);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reduction_ratio_label);
            this.Controls.Add(this.reduction_ratio_box);
            this.Controls.Add(this.save_button);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.error_label);
            this.Controls.Add(this.button_do_steps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cnt_steps_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Игра в Хаос - 3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox cnt_steps_box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_do_steps;
        private System.Windows.Forms.Label error_label;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private Button save_button;
        private TextBox reduction_ratio_box;
        private Label reduction_ratio_label;
        private Label label1;
    }
}

