using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Electricity_Project;
namespace Electricity_Project
{
    public partial class AdminForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }
        private void ClearForm()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtUnits.Text = "";
          
        }


        protected void btnStartEntry_Click(object sender, EventArgs e)
        {
            int count;
            if (int.TryParse(txtConsumerCount.Text, out count) && count > 0)
            {
                ViewState["RemainingConsumers"] = count;
                pnlEntry.Visible = true;
                lblResult.Text = $"Ready to enter {count} consumer(s).";
            }
            else
            {
                lblResult.Text = "Please enter a valid number of consumers.";
            }
        }

        protected void btnSubmitOne_Click(object sender, EventArgs e)
        {
            string number = txtNumber.Text;
            string name = txtName.Text;
            int units;

            try
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(number, @"^EB\d{5}$"))
                    throw new FormatException("Invalid Consumer Number");

              

                if (!int.TryParse(txtUnits.Text, out units))
                {
                    lblResult.Text = "Units must be a number.";
                    return;
                }

                BillValidator validator = new BillValidator();
                string validationMessage = validator.ValidateUnitsConsumed(units);

                if (validationMessage != "Valid")
                {
                    lblResult.Text = validationMessage + "<br/>Please re-enter valid units.";
                    return;
                }


                ElectricityBill bill = new ElectricityBill
                {
                    ConsumerNumber = number,
                    ConsumerName = name,
                    UnitsConsumed = units
                };

                ElectricityBoard board = new ElectricityBoard();
                board.CalculateBill(bill);
                board.AddBill(bill);
              
                lblResult.Text += $"<br/>{bill.ConsumerNumber} {bill.ConsumerName} {bill.UnitsConsumed} Bill Amount : {bill.BillAmount}";

                // Clear fields for next entry
                

                // Decrease remaining count
                int remaining = (int)ViewState["RemainingConsumers"];
                remaining--;
                ViewState["RemainingConsumers"] = remaining;

                if (remaining == 0)
                {
                    pnlEntry.Visible = false;
                    lblResult.Text += "<br/>All consumers added successfully.";
                    ClearForm();
                }
                else
                {
                    lblResult.Text += $"<br/>Please enter details for next consumer ({remaining} remaining).";
                    ClearForm();
                }
            }
            catch (FormatException ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(txtRetrieve.Text, out n) && n > 0)
            {
                ElectricityBoard board = new ElectricityBoard();
                gvBills.DataSource = board.Generate_N_BillDetails(n);
                gvBills.DataBind();
            }
            else
            {
                lblResult.Text = "Please enter a valid number greater than 0.";
            }
        }
       

    }

}







