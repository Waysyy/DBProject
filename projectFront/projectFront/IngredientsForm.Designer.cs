﻿namespace projectFront
{
    partial class IngredientsForm
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.postInfo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.deleteInfoId = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.getInfo = new System.Windows.Forms.Button();
            this.getInfoId = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(63, 548);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 58);
            this.button2.TabIndex = 45;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(63, 626);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(231, 58);
            this.button1.TabIndex = 44;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.label5.Location = new System.Drawing.Point(728, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(338, 47);
            this.label5.TabIndex = 42;
            this.label5.Text = "Сюда вводить ID --->";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.label4.Location = new System.Drawing.Point(932, 118);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 47);
            this.label4.TabIndex = 41;
            this.label4.Text = "Табличка вывода";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.label3.Location = new System.Drawing.Point(605, 453);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 47);
            this.label3.TabIndex = 40;
            this.label3.Text = "<----";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.label2.Location = new System.Drawing.Point(279, 405);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(416, 47);
            this.label2.TabIndex = 39;
            this.label2.Text = "Добавить/изменить тут ";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(25, 453);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(572, 70);
            this.dataGridView2.TabIndex = 38;
            // 
            // postInfo
            // 
            this.postInfo.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.postInfo.Location = new System.Drawing.Point(8, 311);
            this.postInfo.Margin = new System.Windows.Forms.Padding(4);
            this.postInfo.Name = "postInfo";
            this.postInfo.Size = new System.Drawing.Size(713, 70);
            this.postInfo.TabIndex = 37;
            this.postInfo.Text = "Добавить информацию об ингредиенте";
            this.postInfo.UseVisualStyleBackColor = true;
            this.postInfo.Click += new System.EventHandler(this.postInfo_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.textBox1.Location = new System.Drawing.Point(1087, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(327, 54);
            this.textBox1.TabIndex = 36;
            // 
            // deleteInfoId
            // 
            this.deleteInfoId.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteInfoId.Location = new System.Drawing.Point(8, 234);
            this.deleteInfoId.Margin = new System.Windows.Forms.Padding(4);
            this.deleteInfoId.Name = "deleteInfoId";
            this.deleteInfoId.Size = new System.Drawing.Size(713, 70);
            this.deleteInfoId.TabIndex = 35;
            this.deleteInfoId.Text = "Удалить информацию об ингредиенте по id";
            this.deleteInfoId.UseVisualStyleBackColor = true;
            this.deleteInfoId.Click += new System.EventHandler(this.deleteInfoId_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(8, 87);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(713, 65);
            this.button3.TabIndex = 34;
            this.button3.Text = "Изменить информацию об ингредиенте по id";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // getInfo
            // 
            this.getInfo.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getInfo.Location = new System.Drawing.Point(8, 6);
            this.getInfo.Margin = new System.Windows.Forms.Padding(4);
            this.getInfo.Name = "getInfo";
            this.getInfo.Size = new System.Drawing.Size(713, 74);
            this.getInfo.TabIndex = 33;
            this.getInfo.Text = "Получить информацию о всех ингредиентах";
            this.getInfo.UseVisualStyleBackColor = true;
            this.getInfo.Click += new System.EventHandler(this.getInfo_Click);
            // 
            // getInfoId
            // 
            this.getInfoId.Font = new System.Drawing.Font("Segoe Print", 15.75F);
            this.getInfoId.Location = new System.Drawing.Point(8, 160);
            this.getInfoId.Margin = new System.Windows.Forms.Padding(4);
            this.getInfoId.Name = "getInfoId";
            this.getInfoId.Size = new System.Drawing.Size(713, 66);
            this.getInfoId.TabIndex = 32;
            this.getInfoId.Text = "Получить информацию об ингредиенте по id";
            this.getInfoId.UseVisualStyleBackColor = true;
            this.getInfoId.Click += new System.EventHandler(this.getInfoId_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(763, 176);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(591, 522);
            this.dataGridView1.TabIndex = 31;
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Segoe Print", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(407, 574);
            this.clearButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(276, 79);
            this.clearButton.TabIndex = 46;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // IngredientsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 782);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.postInfo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.deleteInfoId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.getInfo);
            this.Controls.Add(this.getInfoId);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IngredientsForm";
            this.Text = "IngredientsForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button postInfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button deleteInfoId;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button getInfo;
        private System.Windows.Forms.Button getInfoId;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button clearButton;
    }
}