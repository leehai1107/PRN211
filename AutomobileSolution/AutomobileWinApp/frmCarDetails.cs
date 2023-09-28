using AutomobileLibrary.BussinessObject;
using AutomobileLibrary.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }
//---------------------------------
        public ICarRepository CarRepository { get; set; }
        public bool InsertOrUpdate { get; set; }//False: Insert, True: Update
        public Car CarInfo { get; set; }
        //-------------------------------------
        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex= 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)//update mode
            {
                //show car to perform updating
                txtCarID.Text = CarInfo.carID.ToString();
                txtCarName.Text = CarInfo.carName;
                txtPrice.Text = CarInfo.price.ToString();
                txtReleaseYear.Text = CarInfo.releaseYear.ToString();
                cboManufacturer.Text = CarInfo.manufacturer.Trim();
            }
        }//end frmCarDetais_Load
        //---------------------------

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car()
                {
                    carID = int.Parse(txtCarID.Text),
                    carName = txtCarName.Text,
                    manufacturer = cboManufacturer.Text,
                    price = decimal.Parse(txtPrice.Text),
                    releaseYear = int.Parse(txtReleaseYear.Text)
                };
                if(InsertOrUpdate == false)
                {
                    CarRepository.insertCar(car);
                }
                else
                {
                    CarRepository.updateCar(car);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new car" : "Update a car");
            }

        }


        private void btnCancel_Click(object sender, EventArgs e) => Close();
      
    }
}
