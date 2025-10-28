using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject//neda
{
    public partial class FrmPizzaOrder : Form
    {
        public FrmPizzaOrder()
        {
            InitializeComponent();
        }

        private void rdSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdMedium_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rdThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rdThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rdEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rdTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        void UpdateToppings()
        {
            UpdatePrice();

            string Topping = "";
            if (chkExstraCheese.Checked)
            {
                Topping += "Extra Cheese";
            }
            if (chkMashrooms.Checked)
            {
                Topping += ", Mashrooms ";
            }
            if (chkOnion.Checked)
            {
                Topping += ", Onion ";
            }
            if (chkTomatoes.Checked)
            {
                Topping += ", Tomatoes ";
            }
            if (chkOlives.Checked)
            {
                Topping += ", Olives ";
            }
            if (chkGreenPeppers.Checked)
            {
                Topping += ", Green Peppers ";
            }
            if(Topping.StartsWith(","))
            {
                Topping= Topping.Substring(1,Topping.Length-1).Trim();
            }
           if(Topping=="")
            {
                Topping = "No Topping";
            }
           lblTopping.Text = Topping;
        }

        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
            }
            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Eat Out";
            }
        }


        void UpdateCrust()
        {
            UpdatePrice();
            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin";
            }

            if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick";
            }
        }

        void UpdateSize()
        {
            UpdatePrice();
            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
            }
            if (rbMedium.Checked)
            {
                lblSize.Text = "Medium";
            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
            }
        }

        void UpdatePrice()
        {
            lblTotalPrice.Text="$"+ CalculateTotalPrice().ToString();
        }

       float CalculateTotalPrice()
        {
            return (CalculateSizePrice() + CalculateCrustPrice() + CalculateTopping())
                * Convert.ToSingle(numericUpDown1.Value);
        }

        float CalculateSizePrice()
        {
            if (rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }
            if (rbLarge.Checked)
            {
                return Convert.ToSingle(rbLarge.Tag);
            }
            else
            {
                return Convert.ToSingle(rbMedium.Tag);
            }
        }
        
        float CalculateCrustPrice()
        {
            if(rbThick.Checked)
                return Convert.ToSingle(rbThick.Tag);
            else
                return Convert.ToSingle(rbThin.Tag);
        }

        float CalculateTopping()
        {
            float ToppingPrice = 0;
            if (chkExstraCheese.Checked)
                 ToppingPrice += Convert.ToSingle(chkExstraCheese.Tag);
            if (chkMashrooms.Checked)
                 ToppingPrice += Convert.ToSingle(chkMashrooms.Tag);
            if (chkTomatoes.Checked)
                ToppingPrice += Convert.ToSingle(chkTomatoes.Tag);
            if (chkOnion.Checked)
                ToppingPrice += Convert.ToSingle(chkOnion.Tag);
            if (chkOlives.Checked)
                ToppingPrice += Convert.ToSingle(chkOlives.Tag);
            if (chkGreenPeppers.Checked)
                ToppingPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            return ToppingPrice;
        }

        private void chkExstraCheese_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMashrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Order Confirm","Confirm",MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successflly", "Success",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                    gbCrust.Enabled = false;
                    gbTopping.Enabled = false;
                    gbWhereToEat.Enabled = false;
                    gbSize.Enabled = false;
                    btnOrderPizza.Enabled = false;
                
            }
            else

                MessageBox.Show("Update your order", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        void ResetForm()
        {
            gbCrust.Enabled = true;
            gbTopping.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbSize.Enabled = true;

            rbMedium.Checked = true;

            rbThin.Checked = true;

            rbEatIn.Checked = true;

            chkExstraCheese.Checked = false;
            chkGreenPeppers.Checked = false;
            chkMashrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkOnion.Checked = false;

            btnOrderPizza.Enabled=true;
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrust();
            UpdateToppings();
            UpdateWhereToEat();
          
        }

        private void FrmPizzaOrder_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdatePrice();
        }
    }
}
