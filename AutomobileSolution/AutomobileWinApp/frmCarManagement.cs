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
    public partial class frmCarManagement : Form
    {
        ICarRepository carRepository = new CarRepository();
        //create a data source
        BindingSource source;
        public frmCarManagement()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadCarList();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails
            {
                Text = "Add car",
                InsertOrUpdate = false,
                CarRepository = carRepository
            };
            if(frmCarDetails.ShowDialog() == DialogResult.OK )
            {
                loadCarList();
                //set focus car inserted
                source.Position = source.Count - 1;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var car = getCarObject();
                carRepository.deleteCar(car.carID);
                loadCarList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Delete a car");
            }
        }

        private void frmCarManagement_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            //Register this event to open the frmCarDetai1s form that performs updating
            dgvCarList.CellDoubleClick += DgvCarList_CellDoubleClick;
        }
        private void DgvCarList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmCarDetails frmCarDetails = new frmCarDetails
            {
                Text = "Update car",
                InsertOrUpdate = true,
                CarInfo = getCarObject(),
                CarRepository = carRepository
            };
            if(frmCarDetails.ShowDialog() == DialogResult.OK)
            {
                loadCarList();
                source.Position = source.Count- 1;
            }
        }

        private Car getCarObject()
        {
            Car car = null;
            try
            {
                car = new Car
                {
                    carID = int.Parse(txtCarID.Text),
                    carName= txtCarName.Text,
                    manufacturer= txtManufacturer.Text,
                    price = decimal.Parse(txtPrice.Text),
                    releaseYear = int.Parse(txtReleaseYear.Text)
                };
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Get car");
            }
            return car;
        }

        public void loadCarList()
        {
            var cars = carRepository.GetCars();
            try
            {
                source = new BindingSource();
                source.DataSource = cars;

                txtCarID.DataBindings.Clear();
                txtCarName.DataBindings.Clear();
                txtManufacturer.DataBindings.Clear();
                txtPrice.DataBindings.Clear();
                txtReleaseYear.DataBindings.Clear();

                txtCarID.DataBindings.Add("Text", source, "carID");
                txtCarName.DataBindings.Add("Text", source, "carName");
                txtManufacturer.DataBindings.Add("Text", source, "manufacturer");
                txtPrice.DataBindings.Add("Text", source, "price");
                txtReleaseYear.DataBindings.Add("Text", source, "releaseYear");

                dgvCarList.DataSource = null;
                dgvCarList.DataSource = source;
                if(cars.Count() == 0)
                {
                    ClearText();
                    btnDelete.Enabled = false;
                }
                else
                {
                    btnDelete.Enabled = true;
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Load car list");
            }
        }

        private void ClearText()
        {
            txtCarID.Text = string.Empty;
            txtManufacturer.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtReleaseYear.Text = string.Empty;
            txtCarName.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();
 
    }
}
