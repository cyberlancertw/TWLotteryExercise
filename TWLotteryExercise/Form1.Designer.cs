
namespace TWLotteryExercise
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRandom = new System.Windows.Forms.Button();
            this.btnBuy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblSector1 = new System.Windows.Forms.Label();
            this.lblSector2 = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRandom
            // 
            this.btnRandom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(66)))));
            this.btnRandom.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRandom.Location = new System.Drawing.Point(735, 24);
            this.btnRandom.Name = "btnRandom";
            this.btnRandom.Size = new System.Drawing.Size(100, 45);
            this.btnRandom.TabIndex = 0;
            this.btnRandom.Text = "產生獎號";
            this.btnRandom.UseVisualStyleBackColor = false;
            this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
            // 
            // btnBuy
            // 
            this.btnBuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(66)))));
            this.btnBuy.Enabled = false;
            this.btnBuy.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnBuy.Location = new System.Drawing.Point(735, 140);
            this.btnBuy.Name = "btnBuy";
            this.btnBuy.Size = new System.Drawing.Size(100, 45);
            this.btnBuy.TabIndex = 1;
            this.btnBuy.Text = "兌獎";
            this.btnBuy.UseVisualStyleBackColor = false;
            this.btnBuy.Click += new System.EventHandler(this.btnBuy_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(194)))), ((int)(((byte)(66)))));
            this.btnClear.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnClear.Location = new System.Drawing.Point(735, 81);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 45);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblSector1
            // 
            this.lblSector1.AutoSize = true;
            this.lblSector1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSector1.Location = new System.Drawing.Point(24, 235);
            this.lblSector1.Name = "lblSector1";
            this.lblSector1.Size = new System.Drawing.Size(29, 72);
            this.lblSector1.TabIndex = 13;
            this.lblSector1.Text = "第\r\n1\r\n區";
            this.lblSector1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSector2
            // 
            this.lblSector2.AutoSize = true;
            this.lblSector2.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSector2.Location = new System.Drawing.Point(24, 369);
            this.lblSector2.Name = "lblSector2";
            this.lblSector2.Size = new System.Drawing.Size(29, 72);
            this.lblSector2.TabIndex = 14;
            this.lblSector2.Text = "第\r\n2\r\n區";
            this.lblSector2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblResult.Location = new System.Drawing.Point(756, 230);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 40);
            this.lblResult.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(193)))), ((int)(((byte)(102)))));
            this.ClientSize = new System.Drawing.Size(847, 491);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblSector2);
            this.Controls.Add(this.lblSector1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnBuy);
            this.Controls.Add(this.btnRandom);
            this.Name = "Form1";
            this.Text = "威力彩模擬器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnBuy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSector1;
        private System.Windows.Forms.Label lblSector2;
        private System.Windows.Forms.Label lblResult;
    }
}

